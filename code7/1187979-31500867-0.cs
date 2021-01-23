    double x = 0;
    Timer timer1 = new Timer();
    
    private void button1_Click(object sender, EventArgs e)
    {
         timer1.Interval = 100;
         timer1.Tick+=new EventHandler(timer1_Tick);
         timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
         x = x + 0.00522222222222222222222222222222;
         textBox1.Text = x.ToString();
    }
