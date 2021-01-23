    var appTimer = new Timer();
    appTimer.Interval = 3600000; // 1 hour, alternatively 1800000 would be 30 minutes.
    appTimer.Tick += new EventHandler(CheckDateTime);
    appTimer.Start();
    private void CheckDateTime(Object obj, EventArgs args)
    {
        // Similarly to the first code, check the day of the week and the hour of the day;
        // then perform an appropriate action, such as notifying the user that it's time
        // to work on something else.  This is a better approach than forcing them to change
        // pages.
    }
