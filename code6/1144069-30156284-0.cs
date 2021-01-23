    Color btnBackColor;
    Timer timer = new Timer();
    private void button1_Click(object sender, EventArgs e)
    {
        btnBackColor = button1.backColor;
        button1.BackColor = Color.Green;    
        timer.Enabled = true;
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        button1.BackColor = btnBackColor;
        timer.Enabled=false;
    }
