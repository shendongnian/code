        static object RequestStatusLock = new object();
        ...
        System.Threading.Timer timer = new System.Threading.Timer(10000); //10second
        timer.Elapsed += timer_elapsed; //timer elapsed will be an event where you will do request status.
                
    void KickWatchDog()
    {
        if(Monitor.TryEnter(RequestStatusLock))
         {
             //calling Stop() and Start() will reset and restart the timer.
             timer.Stop();
             timer.Start();
             Monitor.Exit(RequestStatusLock)
          }
    }
    
    void timer_elapsed(object sender,EventArgs e)
    {
        if(Monitor.TryEnter(RequestStatusLock)
        {
         //if it can  get into this section means that no update from the last 10 second!
         timer.Stop();
         RequestStatus();
         timer.Start();
         Monitor.Exit(RequestStatusLock);
        }
    }
