    public class PaddleManager : MonoBehaviour
    {
       private PaddleRight rightPaddle = null;
       private PaddleLeft  leftPaddle = null;
    
        //Initialize variables
        void Start()
        {
            //Get reference/Cache
            rightPaddle =  GameObject.Find("Paddle Objects/paddleRight").GetComponent<PaddleRight>();
           
            //Get reference/Cache
            leftPaddle =  GameObject.Find("Paddle Objects/paddleLeft").GetComponent<PaddleLeft>();
        }
    
        //Call to pause and unpause
        public void pause(bool pausePaddle)
        {
            rightPaddle.setIsPaused(pausePaddle);
            leftPaddle.setIsPaused(pausePaddle);
        }
    }
