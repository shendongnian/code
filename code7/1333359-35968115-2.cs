        using UnityEngine;
        using System.Collections;
        using System.Collections.Generic;
        using System.Linq;
        
        public class Snake : MonoBehaviour
        {
            Vector2 dir;
            public float snakeSpeed = 0.06f; //To control the speed of the snake
            bool continueMoving = false;
        
            int frame = 0;
        
            void Start()
            {
                dir = Vector2.right * snakeSpeed;
                StartCoroutine(MoveSnake());
            }
        
        
            // Update is called once per frame
            void Update()
            {
                frame += 1;
                // Move in a new Direction?
                if (Input.GetKey(KeyCode.RightArrow))
                    dir = Vector2.right * snakeSpeed;
                else if (Input.GetKey(KeyCode.DownArrow))
                    dir = -Vector2.up * snakeSpeed;    // '-up' means 'down'
                else if (Input.GetKey(KeyCode.LeftArrow))
                    dir = -Vector2.right * snakeSpeed; // '-right' means 'left'
                else if (Input.GetKey(KeyCode.UpArrow))
                    dir = Vector2.up * snakeSpeed;
            }
        
            //Call to start moving
            IEnumerator MoveSnake()
            {
                if (continueMoving)
                {
                    yield break; //Make sure there is one instance of this function running
                }
                continueMoving = true;
        
                //Continue moving nonstop until continueMoving is false or  stopSnake() function is called.
                while (continueMoving)
                {
                    transform.Translate(dir);
        
                    yield return null;
                }
            }
        
            //Call to Stop Moving Snake
            void stopSnake()
            {
                continueMoving = false;
            }
        }
