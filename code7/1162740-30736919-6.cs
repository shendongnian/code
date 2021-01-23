    DateTime end;
    private void button1_Click(object sender, EventArgs e)
    {
        var h = hourNumericUpDown.Value;
        var m = minuteNumericUpDown.Value;
        var s = secondsNumericUpDown.Value;
        if (h != 0 || m != 0 || s != 0)
        {
            var start = DateTime.Now;
            var timeSpan = new TimeSpan(0,h,m,s);
            end = start.Add(timeSpan);
            countDownLabel.Text = timeSpan.ToString();  
            timer1.Start();
        }
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        var timeleft = end - DateTime.Now;
        if (timeLeft.Ticks < 0) 
        {
            countDownLabel.Text = "00:00:00";
            timer1.Stop();
            MessageBox.Show("Times up!", "Time");
        }
        else 
        {
            countDownLabel.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", 
                timeLeft.Hours, timeLeft.Minutes, timeLeft.Seconds);
        }
    }
