using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    private bool birdAlive = true;
    public float minHeight;
    public float maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        while (birdAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidBody.velocity = Vector2.up * flapStrength;
            }
            if (transform.position.y < minHeight || transform.position.y > maxHeight)
            {
                
                birdAlive = false;
                Destroy(gameObject);
            }
        } 
        
            logic.gameOver();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdAlive = false;
    }

    public bool getBirdAlive()
    {
        return birdAlive;
    }
}
