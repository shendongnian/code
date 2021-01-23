    public class YourOtherScript : MonoBehaviour{
        PaddleManager paddleManager = null;
        void Start()
         {
             //Get reference/Cache
             paddleManager = GameObject.Find("GameObjectPaddleManaerIsAttchedTo") .GetComponent<PaddleManager>();
             //To pause
             paddleManager.pause(true);
             //To un-pause
             paddleManager.pause(false);
         }
    }
