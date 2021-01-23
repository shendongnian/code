    private void timer_Kepware_Tick(object sender, EventArgs e)
    {
        if (_KepwareThread == null)
        {
            _KepwareThread = new Thread(...);
        } 
        if (!_KepwareThread.IsAlive) 
        {
            _KewpareThread.Start();
        }
     }
