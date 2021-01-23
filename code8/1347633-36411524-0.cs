    using UnityEngine;
    using System;
    [System.Serializable]
    public class Boundary
    { 
        public float xMin, xMax;
    }
    
    public class BadGuyMovement : MonoBehaviour
    {
        public Transform transformx;
        private Vector3 xAxis;
        private float secondsForOneLength = 1f;
        public Boundary boundary;  //Assuming that you're assigning this value in the inspector
    
        void Start()
        {
            //xAxis = Boundary;  //This won't work. Apples != Oranges.
            
        }
    
        void Update()
        {
            //transform.position = new Vector3(Mathf.PingPong(Time.time, 3), xAxis);  //Won't work, incorrect constructor for a Vector3
            //The correct constructor will take either 2 float (x & y), or 3 floats (x, y & z). Let's ping pong the guy along the X-axis, i.e. change the value of X, and keep the values of Y & Z constant.            
            transform.position = new Vector3( Mathf.PingPong(boundary.xMin, boundary.xMax), transform.position.y, transform.position.z ); 
        }
        void OnTriggerEnter(Collider Player)
        {
            Destroy(Player.gameObject);
        }
    }
