    string HandleMessage(string message, string txt)
    {
        if (message == "UnlockName")
        {
            string firstName = lastLoadedLevel.contact.name.Split(new char[] { ' ' })[0];
            return txt.Replace("C:", firstName + ":");
        }
    }
    void OutputText(string txt, string message) 
    {
        txt = HandleMessage(message, txt);
        txt = txt.Replace("D:", "D's name:");
        txt = txt.Replace("[name]", PlayerPrefs.GetString("name"));
        chat.AddText(txt, delegate 
            {
                options.gameObject.SetActive(true);
            });
    }
