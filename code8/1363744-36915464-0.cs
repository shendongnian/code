    public class PauseCanvas : MonoBehaviour
    {
    
        public Button resumeButton;
        public Button backToMainMenuButton;
        public Button exitGameButton;
    
        public Canvas gameCanvas;
        public Canvas mainMenuCanvas;
    
        public Slider volumeSlider;
    
        public float startVolume = 1f;
        public float currentVolume;
    
        string newVolume = "VOLUME_SLIDER"; //Can change to whatever you want as long as it is not null or empty
    
    
        void Start()
        {
            //Load volume from prevois saved state. If it does not exist, use 1 as default
            volumeSlider.value = PlayerPrefs.GetFloat(newVolume, 1);
            currentVolume = volumeSlider.value;
        }
    
        void UpdateVolume(float _volume)
        {
            currentVolume = _volume;
    
            PlayerPrefs.SetFloat(newVolume, _volume);
            PlayerPrefs.Save();
        }
    
        void OnEnable()
        {
            //Register Button Events
            resumeButton.onClick.AddListener(() => buttonCallBack(resumeButton));
            backToMainMenuButton.onClick.AddListener(() => buttonCallBack(backToMainMenuButton));
            exitGameButton.onClick.AddListener(() => buttonCallBack(exitGameButton));
    
            //Register Slider Events
            volumeSlider.onValueChanged.AddListener(delegate { sliderCallBack(volumeSlider); });
        }
    
        private void sliderCallBack(Slider sliderMoved)
        {
            //Volume Slider Moved
            if (sliderMoved == volumeSlider)
            {
                UpdateVolume(sliderMoved.value);
            }
        }
    
        private void buttonCallBack(Button buttonPressed)
        {
            //Resume Button Pressed
            if (buttonPressed == resumeButton)
            {
                Time.timeScale = 1;
                //Hide this Pause Canvas
                gameObject.SetActive(false);
    
                //Show Game Canvas
                gameCanvas.gameObject.SetActive(true);
            }
    
            //Back To Main Menu Button Pressed
            if (buttonPressed == backToMainMenuButton)
            {
                //Hide this Pause Canvas
                gameObject.SetActive(false);
    
                //Show Main Menu Canvas
                //Score.Inicializar();
                SceneManager.LoadScene("Menu");
            }
    
            //Exit Game Button Pressed
            if (buttonPressed == exitGameButton)
            {
    #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
    #else
                Application.Quit();
    #endif
            }
        }
    
        void OnDisable()
        {
            //Un-Register Button Events
            resumeButton.onClick.RemoveAllListeners();
            backToMainMenuButton.onClick.RemoveAllListeners();
            exitGameButton.onClick.RemoveAllListeners();
    
            //Un-Register Slider Events
            volumeSlider.onValueChanged.RemoveAllListeners();
        }
    }
