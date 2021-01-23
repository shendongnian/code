    DateTime startTime = DateTime.Now;	
    private void timer1_Tick(object sender, EventArgs e)
    {
        Time.Text = DateTime.Now.Subtract(startTime).ToString(@"mm\:ss");
    }
    private void timer_Click(object sender, EventArgs e)
    {
        startTime = DateTime.Now;	
        timer1.Start();
    }
