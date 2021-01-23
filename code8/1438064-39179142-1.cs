    public class ClickDetector: MonoBehaviour
    {
        PlayerController playerController;
    
        void Start()
        {
            playerController = GameObject.Find("GameObjectPlayerControlIsAttachedTo").GetComponent<PlayerController>();
        }
    
        void OnMouseDown()
        {
            //Notify our PlayerController script that there was a click
            playerController.OnGameObjectClicked(this.gameObject);
        }
    }
