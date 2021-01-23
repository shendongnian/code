    void OnGUI()
    {
        GUI.Button (new Rect(400,40,45,45),"text1");
        if (Time.time > 2) {
            GUI.Button (new Rect(800,40,45,45),"text1");
        }
    } 
