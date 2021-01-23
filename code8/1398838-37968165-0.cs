    public Button button1;
    public Button button2;
    
    public Sprite newSprite;
    
    void OnEnable()
    {
        //Register Button Events
        button1.onClick.AddListener(() => buttonCallBack(button1));
        button2.onClick.AddListener(() => buttonCallBack(button2));
    }
    
    private void buttonCallBack(Button buttonPressed)
    {
        if (buttonPressed == button1)
        {
            //Your code for button 1
            buttonPressed.image.sprite = newSprite;
        }
    
        if (buttonPressed == button2)
        {
            //Your code for button 2
        }
    }
    
    void OnDisable()
    {
        //Un-Register Button Events
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
    }
