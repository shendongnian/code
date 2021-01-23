    public string thePassword = "12345";
    void OnGUI()
    {
        passwordToEdit = GUI.PasswordField(new Rect(10, 10, 200, 20), 
                                           passwordToEdit, "*"[0], 25);
    }
