    public class EnableComponents : MonoBehaviour
    {
        private Light myLight;
        
        
        void Start ()
        {
            myLight = GetComponent<Light>();
        }
        
        
        void Update ()
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                myLight.enabled = !myLight.enabled;
            }
        }
    }
 
