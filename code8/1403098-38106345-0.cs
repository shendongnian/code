    int pendingDeletes = 0;
    int TipState = 0; // keeps the state of the notifyIcon, 
                      // 0 = initial,
                      // 1 is about to be shown
                      // above 1 is waiting to reset to 0
    
    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        pendingDeletes++;
        if (TipState == 0)
        {
            TipState++; 
            // it didn't want to start http://stackoverflow.com/a/18348878
            this.Invoke( new MethodInvoker( () => timer1.Start()));
        }
    
    }
    
    // tick every 500 ms
    private void timer1_Tick(object sender, EventArgs e)
    {
        Trace.WriteLine(TipState);
        switch(TipState)
        { 
            case 1:
                notifyIcon1.BalloonTipText = String.Format("{0} deleted file(s)", pendingDeletes);
                notifyIcon1.ShowBalloonTip(500);
                pendingDeletes = 0;
                TipState++;
                break;
            case 2:
                // do nothing
                TipState++;
                break;
            case 3:
                // maybe do something if pendingDeletes > 0
                timer1.Stop();
                // back to initial state
                TipState = 0;
                break;
            default:
                // prevent mishaps
                TipState = 0;
                break;
        }
    }
