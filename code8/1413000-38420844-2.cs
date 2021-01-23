    private DateTime endTime;
    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    private void button1_Click(object sender, EventArgs e)
    {
        var minutes = 0;
        if (int.TryParse(textBox1.Text, out minutes) && timer.Enabled == false)
        {
            endTime = DateTime.Now.AddMinutes(minutes);
            timer.Interval = 1000;
            timer.Tick -= new EventHandler(timer_Tick);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            UpdateText();
        }
    }
    void timer_Tick(object sender, EventArgs e)
    {
        UpdateText();
    }
    void UpdateText()
    {
        var diff = endTime.Subtract(DateTime.Now);
        if (diff.TotalSeconds > 0)
            label1.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                       diff.Hours, diff.Minutes, diff.Seconds);
        else
        {
            this.Text = "00:00:00";
            timer.Enabled = false;
        }
    }
