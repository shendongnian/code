    private GameObject mainMenu, options;
    public Button OptionButton;
    
    void Awake()
    {
        mainMenu = GameObject.Find("MainMenuCanvas");
        options = GameObject.Find("OptionCanvas");
    }
    
    void Start()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
    }
    
    void OnEnable()
    {
        //Register Button Event
        OptionButton.onClick.AddListener(() => OptionButtonCallBack());
    
    }
    
    //Will be called when OptionButton is clicked
    private void OptionButtonCallBack()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
    
    void OnDisable()
    {
        //Un-Register Button Event
        OptionButton.onClick.RemoveAllListeners();
    }
