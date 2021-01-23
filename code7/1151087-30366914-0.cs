    //do not forget
    using System.Timers;
    
    private Timer _timer;
    private static long _id;
    private static bool _returnValue;
    private static int _achievedTime;
    
    public static bool StartTimeOut()
    {
      //set your known values (you need to check these values over time
      _id = ID;
      _achievedTime = 0;
      _returnValue = true;
      
      //start your timer
      Start();
      
      while(_timer.Enabled)
      {
        //an empty while loop that will run as long as the timer is enabled == running
      }
      //as soon as it stops
      return _returnValue;
    }
    
    //sets the timer values
    private static void Start()
    {
      _timer = new Times(100); //describes your interval for every 100ms
      _timer.Elapsed += HandleTimerElapsed;
      _timer.AutoReset = true; //will reset the timer whenever the Elapsed event is called
      
      //start your timer
      _timer.Enabled = true; //Could also be _timer.Start();
    }
    
    //handle your timer event
    //Checks all your values
    private static void HandleTimerElapsed(object sender, ElapsedEventArgs e)
    {
      _achievedTime += _timer.Interval;
      //the ID changed => return true and stop the timer
      if(ID!= _id)
      {
          _returnValue = true;
          _timer.enabled = false; //Could also be _timer.Stop();
      }
      if(CalcVar == 0) //calcVar value reached 0 => return false and stop the timer
      {
        _returnValue = false;
        _timer.Enabled = false;
      }
      if(_achievedTime = 30000) //your 30s passed, stop the timer
        _timer.Enabled = false;          
    }
