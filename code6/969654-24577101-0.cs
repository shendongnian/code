    DispatcherTimer dispatcherTimer = new DispatcherTimer();
    dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
    dispatcherTimer.Interval = new TimeSpan(0, 0, 3);   //fire after 3 seconds
    ...
    private void ShowMyImage()
    {
        // logic to show your image
        dispatcherTimer.Start();
    }
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        // logic to show your image
        dispatcherTimer.Stop();
    }
