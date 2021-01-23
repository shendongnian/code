    private void button1_Click(object sender, EventArgs e)
    {
        if (!timer1.Enabled) {
            CountUp = 0;
            timer1.Enabled = true;
            label1.Text = "Timer1 Running";
        } else {
            timer1.Enabled = false;
            label1.Text = "Timer1 Stopped (Manual)";
        }
    }
    // Later on, when a tick occurs and the timer should end..
    // The timer callback runs on the UI thread it was created on.
    private void timer1_Tick(object sender, EventArgs e)
    {
        CountUp++;
        if (CountUp > 10) {
            timer1.Enabled = false;
            label1.Text = "Timer1 Stopped (Time up)";
        }
    }
