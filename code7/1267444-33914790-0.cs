    Time ftmr=new Timer();
    //set time interval 5 sec
    ftmr.Interval = 5000 / 100; // 100 attempts
    //starts the timer
    ftmr.Start();
    ftmr.Tick += Ftmr_Tick;
    int opacity = 100;
    private void Ftmr_Tick(object sender, EventArgs e)
    {
        this.Opacity = opacity--;
        this.Refresh();
    }
