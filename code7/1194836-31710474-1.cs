    public void UpdateStatus()
    {
        if (!File.Exists("logindata.xml"))
        {
            StatusText = "Please enter your desired username and password.";
        }
        else
        {
            StatusText = "Logged In";
        }
    }
