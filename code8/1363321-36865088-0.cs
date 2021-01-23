    private void timer_Tick(object sender, EventArgs e)
    {
        log.Info("Dashboard - Refreshing...");
        System.Diagnostics.Debug.WriteLine(">>Timer tick");
        IsRefreshing = Visibility.Visible;
    
        // To make sure the overlay is visible to the user, let it be on screen for at least a second (2x half a second)
        Thread.Sleep(500);
    
        if (selectedServer != null)
        {
            KeepSelection(selectedServer);
        }
        else
        {
            GetListDashboard();
        }
    
        // 2nd half second.
        Thread.Sleep(500);
        IsRefreshing = Visibility.Collapsed;
    
        if (hasNewError == true)
        {
            System.Diagnostics.Debug.WriteLine("List has new error");
            PlayWarningSound();
            HasNewError = false;
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("List has no new error");
            HasNewError = false;
        }
        System.Diagnostics.Debug.WriteLine(">>End timer");
    
        log.Info("Dashboard - Refreshed.");
    }
