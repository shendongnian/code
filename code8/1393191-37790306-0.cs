    public class PlaneMover : MonoBehaviour {
    private GameManagerScript GMS; // Reference to my GameManager Script
        public float scrollSpeed;
        public float tileSizeZAxis;
        public float acceleration; //This has to be a negative number in the inspector. Since our plane is coming down.
    
        private Vector3 startPosition;
    
        Animation animation;
        public AnimationClip animationClip; //Assign from Editor
    
        void Start () {
    
            GMS = GameObject.Find ("GameManager").GetComponent<GameManagerScript> (); //Finds the Script at the first frame
    
            // Transform position of the quad
            startPosition = transform.position;
    
            animation = GetComponent<Animation>();
    
            //Add crawing Animation
            animation.AddClip(animationClip, "Crawling");
            //Add other animation clips here too if there are otheres
        }
    
        void Update () 
        {
    
            if (GMS.countDownDone) //Everything starts once the countdown ends. 
            {
    
                /* Every frame - time in the game times the assigned scroll speed 
                    and never exceed the length of the tile that we assign */
                float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZAxis);
    
                // New position equal to the start position plus vector3forward times new position
                transform.position = startPosition + Vector3.forward * newPosition; // was vector3.forward
    
                scrollSpeed += Time.deltaTime * acceleration; // This makes the plane increase in speed over time with
                                                              // whatever our acceleration is set to.
    
                //Play Animation
                animation.PlayQueued("Crawling", QueueMode.CompleteOthers);
            }
        }
    } }
