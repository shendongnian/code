    public class TheScript : MonoBehaviour
    {
        public GameObject nextLevelButton;
    
        private void Start()
        {
            nextLevelButton = GameObject.Find("Button");
            nextLevelButton.SetActive(false);
        }
    }
