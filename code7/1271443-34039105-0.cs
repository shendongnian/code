    Timer timer;
    private void Initialiser()
    {
        Timer timer = new Timer();
        timer.Interval = 3600000;//Set interval to an hour in the form of milliseconds.
        timer.Tick += new EventHandler(timer_Tick);
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        //The function you wish to do every hour.
    }
