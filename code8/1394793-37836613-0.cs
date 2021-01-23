    public class WallFader : MonoBehaviour
    {
        public GameObject wallone;
    
        private Vector3 wallonetransform;
    
        private Color wallonecolor;
        Renderer renderer;
    
        public GameObject player;
        private Vector3 playerposition;
    
        private float PPX;
        private float PPZ;
    
        // Use this for initialization
        void Start()
        {
            wallonetransform = wallone.GetComponent<Transform>().position;
            renderer = wallone.GetComponent<Renderer>();
            wallonecolor = wallone.GetComponent<Renderer>().material.color;
        }
    
        // Update is called once per frame
        void Update()
        {
    
    
            playerposition = player.transform.position;
            PPX = playerposition.x;
            PPZ = playerposition.z;
    
            // Distance to the large flat wall
            float wallonedist = wallonetransform.z - PPZ;
    
            if (wallonedist > 10)
            {
                wallonecolor.a = 0;
                renderer.material.color = wallonecolor; //Apply the color
            }
    
            else
            {
                //fade in script
            }
        }
    }
 
