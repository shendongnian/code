    //initialising
    Timer T = new System.Timers.Timer(2000); //Timer with two second interval
    aTimer.Elapsed += TimerElapsed;
    
    private int a = 0;
    public int A
    {
      get
      {
        return a;
      }
      set
      {
        if (value == 1)
        {
          T.Start();
        }
        a = value;
      }
    }
    private void TimerElapsed(Object source, System.Timers.ElapsedEventArgs e)
    {
      //timer elapsed code
      T.Stop();
    }
