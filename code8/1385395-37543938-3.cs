    using UnityEngine;
    using System.Collections;
    
    public class PlayerController : MonoBehaviour
    {
        public float speed = 80.0f; // Code for how fast the ball can move. Also it will be public so we can change it inside of Unity itself. 
        public Rigidbody player1RB; //Player 1 Rigidbody
        public Rigidbody player2RB; //Player 2 Rigidbody
    
    
        //Player 1 Code with aswd keys
        void Player1Movement()
        {
            if (Input.GetKey(KeyCode.A))
            {
                player1RB.AddForce(Vector3.left * speed);
    
            }
    
            if (Input.GetKey(KeyCode.D))
            {
                player1RB.AddForce(Vector3.right * speed);
    
            }
    
            if (Input.GetKey(KeyCode.W))
            {
                player1RB.AddForce(Vector3.forward * speed);
    
            }
    
            if (Input.GetKey(KeyCode.S))
            {
                player1RB.AddForce(Vector3.back * speed);
    
            }
        }
    
        //Player 2 Code with arrow keys
        void Player2Movement()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                player2RB.AddForce(Vector3.left * speed);
    
            }
    
            if (Input.GetKey(KeyCode.RightArrow))
            {
                player2RB.AddForce(Vector3.right * speed);
    
            }
    
            if (Input.GetKey(KeyCode.UpArrow))
            {
                player2RB.AddForce(Vector3.forward * speed);
    
            }
    
            if (Input.GetKey(KeyCode.DownArrow))
            {
                player2RB.AddForce(Vector3.back * speed);
    
            }
        }
    
        // Update is called once per frame
        void FixedUpdate()
        {
            Player1Movement();
            Player2Movement();
        }
    }
