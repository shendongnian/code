    public ReadFile()
    {
        //before this I already assigned to timer1 the tick event and start
        timer2.Tick -= new EventHandler(Event_Tick);
        timer2.Tick += new EventHandler(Event_Tick);
        timer2.Interval = new TimeSpan(0, 0, 1);
        timer2.Start();
    }
