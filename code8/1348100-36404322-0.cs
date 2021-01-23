    Timer timer = new Timer();      //using using System.Timers;
    timer.Interval = 5000;          //Time for 1 interval in milliseconds
    timer.AutoReset = true;         //Start again when elapsed
    timer.Elapsed += Timer_Elapsed; //Method called when timer elapsed
    private int _lastRowCount;
    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
       //Check row Count
       //Use your SqlClient here to get the rowCount
       
       if(_lastRowCount < currentRowCount)
       {
          //Row was added: Do your work here:
       }
      //Set the currentRowCount as _lastRowCount for the next check
       _lastRowCount = "yourValue";
    }
