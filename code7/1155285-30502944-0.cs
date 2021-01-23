    private Timer myTimer = new Timer();
  
    private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)     
    {       
      lbl.Text = counter.ToString();    
    }
    private void start_Click(object sender, EventArgs e)
    {
       myTimer.Tick += new EventHandler(TimerEventProcessor);      
       myTimer.Interval = 1000;
       myTimer.Start();
    }
    }
