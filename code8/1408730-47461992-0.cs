    private System.Threading.Timer _timer;
        
    ...
    
    // setup timer with callback
    _timer = new System.Threading.Timer(OnTimerTick);
    
    // start timer: duetime = 0 when to first execute callback (0 = right now) and intervall 5s
    _timer.Change(0, 5000);
    
    ...
    
    // stop timer
    _timer.Change(Timeout.Infinite, Timeout.Infinite);
    
    ...
    
    private void OnTimerTick(object state)
    {
    	// do the intervall stuff here
    }
  
      
