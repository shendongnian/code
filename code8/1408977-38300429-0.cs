    using UnityEngine;
    using System.Collections;
    
    public class TestSample : MonoBehaviour {
    
        public float radius  = 40.0f;
        public float speed = 5.0f;
    
        // The point we are going around in circles
        private Vector2 basestartpoint;
    
        // Destination of our current move
        private Vector2 destination;
    
        // Start of our current move
        private Vector2 start;
    
        // Current move's progress
        private float progress = 0.0f;
    
    	// Use this for initialization
    	void Start () {
            start = transform.localPosition;
            basestartpoint = transform.localPosition;
            progress = 0.0f;
    
            PickNewRandomDestination();
    	}
    
    	// Update is called once per frame
    	void Update () {
            bool reached = false;
    
            // Update our progress to our destination
            progress += speed * Time.deltaTime;
    
            // Check for the case when we overshoot or reach our destination
            if (progress >= 1.0f)
            {
                progress = 1.0f;
                reached = true;
            }
    
            // Update out position based on our start postion, destination and progress.
            transform.localPosition = (destination * progress) + start * (1 - progress);
    
            // If we have reached the destination, set it as the new start and pick a new random point. Reset the progress
            if (reached)
            {
                start = destination;
                PickNewRandomDestination();
                progress = 0.0f;
            }
    	}
    
        void PickNewRandomDestination()
        {
            // We add basestartpoint to the mix so that is doesn't go around a circle in the middle of the scene.
            destination = Random.insideUnitCircle * radius + basestartpoint;
        }
    }
