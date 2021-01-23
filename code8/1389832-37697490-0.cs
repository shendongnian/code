    private bool isPressed = false;
    void Start()
    {
        if (PlayerPrefs.GetInt("Pressed") != 0)
            isPressed = true;
        else
            isPressed = false;
    }
    void Update()
    {
        if (isPressed)
            print("Hello World");
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isPressed) isPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isPressed = false;
        }
    }
    public void SaveButtonState()
    {
        if(isPressed)
            PlayerPrefs.SetInt("Pressed", 1);
        else
            PlayerPrefs.SetInt("Pressed", 0);
    }
