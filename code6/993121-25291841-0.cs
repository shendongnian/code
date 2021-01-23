    DateTime currentDate = DateTime.Now;
    if (Settings.FutureDate)
    {
        //If three days has passed, notify user
        if (currentDate >= Settings.FutureDate.Value) 
        {
            MessageBox.Show("Three days has passed.");
        }
    }
