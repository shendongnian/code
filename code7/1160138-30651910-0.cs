    System.Windows.Forms.Timer t = null;
    private void StartTimer()
    {
        t = new System.Windows.Forms.Timer();
        t.Interval = 1000;
        t.Tick += new EventHandler(t_Tick);
        t.Enabled = true;
    }
    
    void t_Tick(object sender, EventArgs e)
    {
        lblTime.Text = DateTime.Now.ToString();
    }
