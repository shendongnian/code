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
        if(DateTime.Now>=endTime)
        {
            timer1.Stop();
            MessageBox.Show("Time is Over.");
        }
    }
