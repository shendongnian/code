    private void button2_Click(object sender, EventArgs e)
    {
        timer1.Interval = 100;
        //start the timer
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        button1.Left += 20;
        //check position of button. When it is outside the width of form stop the timer.
        if(button1.Left >= this.Width) 
        {
            timer1.Stop();
        }
    }
