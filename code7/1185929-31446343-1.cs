    public GUISkin yourGuiSkinObject;
    void Start()
    {
        int scale = Screen.height / 20;
        yourGuiSkinObject.button.fontsize = scale;
    }
    void OnGui()
    {
        if(GUI.Button(new Rect(0, 0, 100, 20), "Test", yourGuiSkinObject.button))
        {
        }
    }
