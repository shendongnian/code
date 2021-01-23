    public class PauseMenu : MonoBehaviour {
    
        Canvas canvas;
        public UserInput playerInput; // Drag the Player object into this field in the editor
        public Button Button2;
    
        void Start()
        {
            Debug.Log ("asdf");
            canvas = GetComponent<Canvas>();
            canvas.enabled = false;
            ResourceManager.MenuOpen = false;
            Button2.GetComponent<Button>().onClick.AddListener(() => { Resume();});
            playerInput.enabled = false;
        }
    }
