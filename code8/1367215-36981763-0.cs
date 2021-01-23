    delegate void CreateKeyDelegate();
    static void OnTimerElapsed(Object source, System.Timers.ElapsedEventArgs e)
    {
        if(!(timer1.Enabled || timer2.Enabled))
        {
            Control control; // any of your GUI controls!
            control.BeginInvoke(new CreateKeyDelegate(CreateKey));
        }
    }
    void CreateKey()
    {
        // your code here
    }
