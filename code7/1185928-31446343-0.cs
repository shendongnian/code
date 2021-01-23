    public GUISkin yourGuiSkinObject;
    void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 100, 20), "Test", yourGuiSkinObject.button))
        {
        //Do something.
        }
    }
