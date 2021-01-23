    public class Test : MonoBehaviour
    {
        [Tooltip("Select your type of fade")]
        public FadeOperations[] fadeOperations;
        //Loop for debug X  NOTE: Start method runs only one time.dont expect it to run it for multiple time 
        private void Start()
        {
            foreach(var operation in fadeOperations)
            {
                Debug.Log(operation.fadeType);
                switch (operation.fadeType)
                {
                    case FadeManager.fadeIn:
                        Debug.Log("Fadein"); // write your fading in code here
                        break;
    
                    case FadeManager.fadeOut:
                        Debug.Log("Fadeout"); // write your fading out code here
                        break;
                }
            }
         }
    }
