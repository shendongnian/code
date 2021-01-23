    void Start()
    {
        buttonText1 = button1.GetComponentInChildren<Text>();
        buttonText2 = button2.GetComponentInChildren<Text>();
    }
    
    void Update()
    {
        buttonText = Time.time.ToString();
    }
    
    public Button button1;
    public Button button2;
    
    Text buttonText1;
    Text buttonText2;
    
    string _buttonText = "HI";
    public string buttonText
    {
        set
        {
    
            _buttonText = value;
    
            //Change Text 1
            if (buttonText1 != null)
            {
                buttonText1.text = _buttonText;
            }
    
            //Change Text 2
            if (buttonText2 != null)
            {
                buttonText2.text = _buttonText;
            }
        }
    
        get
        {
            return _buttonText;
        }
    }
