    public void Form_Load(object sender, EventArgs e)
    {
        // Moved here, supposing that you don't not needed to
        // set them to same value every second....
        Application.EnableVisualStyles();
        progressBar1.Style = ProgressBarStyle.Continuous;
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        t.Interval = 1000;
        t.Tick += timeElapsed;
        t.Start();
    }
    private void timeElapsed(object sender, EventArgs e)
    {
        progressBar1.Value = (int)(power.BatteryLifePercent * 100);
        label1.Text = string.Format("{0}%", (power.BatteryLifePercent * 100));
    }
