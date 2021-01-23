    Time ftmr=new Timer();
    //set time interval 5 sec
    ftmr.Interval = 5000 / 100; // 100 attempts
    //starts the timer
    ftmr.Start();
    ftmr.Tick += Ftmr_Tick;
    double opacity = 1;
    private void Ftmr_Tick(object sender, EventArgs e)
    {
        this.Opacity = opacity;
        opacity -= .01;
        this.Refresh();
        if (this.Opacity <= 0)
        {
            ftmr.Stop();
        }
    }
