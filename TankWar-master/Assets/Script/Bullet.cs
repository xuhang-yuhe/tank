using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 1f;
    public bool isPlayerBullet;


	void Start () {
		
	}
	

	void Update () {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Tank":
                if(!isPlayerBullet)
                {
                    collision.SendMessage("Die");
				   Destroy(gameObject);
                }
			     //Destroy(gameObject);

                 break; 
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Barriar":
                Destroy(gameObject);
                break;
            case "Enemy":
                if (isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            default:
                break;
        }
    }

}
