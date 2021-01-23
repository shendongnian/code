    private AutoCloseMsb(string text, string caption, int timeout)
    {
    	_caption = caption;
    	_timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
    		null, timeout, System.Threading.Timeout.Infinite);
    	// the next call blocks, until either the user
    	// or the timer closes the the messagbox
    	MessageBox.Show(text, caption);
    	// now we can stop this timer
    	_timeoutTimer.Change(Timeout.Infinite, Timeout.Infinite);
    	// and dispose it
    	_timeoutTimer.Dispose();
    }
