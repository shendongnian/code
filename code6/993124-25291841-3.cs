    DateTime currentDate = DateTime.Now;
    DateTime settingsDate = DateTime.Parse(Settings.FutureDate.Value);
    if (currentDate >= settingsDate) 
    {        //If three days has passed, notify user
        if (currentDate >= Settings.FutureDate.Value) 
        {
            MessageBox.Show("Three days has passed.");
        }
    }
