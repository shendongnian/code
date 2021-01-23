     public void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            //get the username
            string get_userName = Environment.UserName;
            Debug.WriteLine(e.Reason);
            statusform.colourchanger(); //access instance object
        }
