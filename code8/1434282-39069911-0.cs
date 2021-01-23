    public class GameManager : MonoBehaviour
    {
    
        public bool isMenuActive { get; set; }
    
        void Awake()
        {
            isMenuActive = true;
        }
    
        void OnGUI()
        {
            const int Width = 300;
            const int Height = 200;
            if (isMenuActive)
            {
                Rect windowRect = new Rect((Screen.width - Width) / 2, (Screen.height - Height) / 2, Width, Height);
                GUILayout.Window(0, windowRect, MainMenu, "Main menu");
            }
        }
    
        private void MainMenu(int windowID)
        {
            // Debug.Log("menu is displayed");
        }
    }
