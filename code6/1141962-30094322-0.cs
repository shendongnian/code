    protected void Page_Load(object sender, EventArgs e)
    {
        System.Timers.Timer tm = new System.Timers.Timer();
        tm.Elapsed += new System.Timers.ElapsedEventHandler(tm_Elapsed);
        tm.Interval = 1000;
        tm.Start();
    }
    
    void tm_Tick(object sender, EventArgs e)
    {
         int lbl = Convert.ToInt32(label1.Text);
         label1.Text = (lbl + 1).ToString();
    }
