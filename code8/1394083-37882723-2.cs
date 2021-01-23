     private myMainFunction(){
      LinuxHiResTimer timReallyFast = new LinuxHiResTimer();
      timReallyFast.Interval=25; // 
      timReallyFast.Tick += new EventHandler(timReallyFast_Tick);
      timReallyFast.Enabled = true;
    }
    private void timReallyFast_Tick(System.Object sender, System.EventArgs e) {
    // Do this quickly i.e. 
     PollSerialPort();
    }
     
