    public Button someButton;
    
    void OnEnable()
    {
        //Register Button Events
        someButton.onClick.AddListener(() => buttonCallBack("Hello Affan", 88));
    }
    
    private void buttonCallBack(string myStringValue, int myIntValue)
    {
        Debug.Log("Button Clicked. Received string: " + myStringValue + " with int: " + myIntValue);
    }
    
    void OnDisable()
    {
        //Un-Register Button Events
        someButton.onClick.RemoveAllListeners();
    }
