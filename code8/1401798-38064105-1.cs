    using UnityEngine;
    using System.Collections;
    
    public class Collision : MonoBehaviour {
    
        public Vector3 up, down;
        public bool isUp = false;
        public float speed = 5f;
    
        float startTime,
            length;
        bool isMoving = false;
    
    	void Start () {
            //initialise the platform to a position
            if (isUp) transform.position = up;
            else transform.position = down;
    
            length = Vector3.Distance(up, down);
    	}
    	
        void Update()
        {
            if (isUp)
            {
                //move Down
                transform.position = Vector3.Lerp(up, down, ((Time.time - startTime) * speed) / length);
            }
            else
            {
                //move Up
                transform.position = Vector3.Lerp(down, up, ((Time.time - startTime) * speed) / length);
            }
        }
    
        //move down
        void OnCollisionEnter(Collision col)
        {
            if (!isMoving)
            {
                startTime = Time.time;
                isMoving = true;
            }
        }
    
        //move up
        void OnCollisionExit(Collision col)
        {
            if (!isMoving)
            {
                startTime = Time.time;
                isMoving = true;
            }
        }
    }
