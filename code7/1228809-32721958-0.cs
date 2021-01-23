    private DateTime timerStart;
    private TimeSpan duration;
    private void Form1_Load(object sender, EventArgs e)
    {
        Timer MyTimer = new Timer();
        MyTimer.Interval = 1000; // tick at one second to update the UI
        MyTimer.Tick += new EventHandler(MyTimer_Tick);
        duration = whatever...// Input from user
        timerStart = DateTime.Now;
        MyTimer.Start();
    }
    
    private void changeTimer(TimeSpan newValue) {
       TimeSpan alreadyElapsed = DateTime.Now.Subtract(timerStart);
       MyTimer.Stop();
       MyTimer.Interval = (int)newValue.Subtract(alreadyElapsed).TotalMilliseconds;
      MyTimer.Start();
    }
    
    private void MyTimer_Tick(object sender, EventArgs e)
    {
        TimeSpan alreadyElapsed = DateTime.Now.Subtract(timerStart);
        // update the UI here using the alreadyElapsed TimeSpan
        if(alreadyElapsed > duration) 
        {
        //pop my GUI application
        }
    }
