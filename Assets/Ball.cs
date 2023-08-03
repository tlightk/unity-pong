using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 30;

    void Start()
    {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // left racket
        if (col.gameObject.name == "RacketLeft")
        {
            // calculate hit factor
            float y = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.y);

            // calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // set velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
        {
            return (ballPos.y - racketPos.y) / racketHeight;
        }

        // right racket
        if (col.gameObject.name == "RacketRight")
        {
            // calculate hit factor
            float y = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.y);

            // calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // set velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}
