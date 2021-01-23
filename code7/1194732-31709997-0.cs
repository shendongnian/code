    private Timer timer = new Timer();
    
    bool closing = false;
    int desiredWidth = 300
    private void ConfigureTimer()
    {
       timer.Tick += timer_Tick;
       timer.Interval = 16;
    }
    
    private void timer_Tick(object sender, EventArgs e){
    {
       if(closing)
       {
          panel2.Width-=15;
          if(panel2.Width < 0) 
          {
            panel2.Width = 0;
            timer.Stop();
          }
       }else{
           panel2.Width+=15;
          if(panel2.Width >= desiredWidth) 
          {
            panel2.Width = desiredWidth;
            timer.Stop();
          }
       }
    }
    
    private void SwitchPanelState()
    {
        closing = !closing;
        timer.Start();
    }
