    DateTime endTime;
    private void Form2_Load(object sender, EventArgs e)
    {
        var startTime = DateTime.Now;
        endTime = startTime.AddMinutes(15);
        timer1.Interval = 1000;
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        var diff = endTime.Subtract(DateTime.Now);
        this.Text= string.Format("Remaining: {0} d {1:D2}:{2:D2}:{3:D2}", 
                                  diff.Days, diff.Hours, diff.Minutes, diff.Seconds);
        if(DateTime.Now>=endTime)
        {
            timer1.Stop();
            this.Text = "Remaining: 0 d 00:00:00";
            MessageBox.Show("Finished.");
        }
    }
