    int i = 0;// Create i at class level to ensure the value is maintain between tick events.
    private void timer1_Tick(object sender, EventArgs e)
    {
        string str = "Herman Lukindo";
        // Check to see if we have reached the end of the string. If so, then stop the timer.
        if(i >= str.Length)
        {
            StopTimer();
        }
        else
        {
            textBox1.Text += str[i];
            i++; 
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        // If timer is running then stop it.
        if(timer1.Enabled)
        {
            StopTimer();
        }
        // Otherwise (timer not running) start it.
        else
        {
            StartTimer();
        }
    }
    
    void StartTimer()
    {
        i = 0;// Reset counter to 0 ready for next time.
        textBox1.Text = "";// Reset the text box ready for next time.
        timer1.Enabled = true;
        button1.Text = "Stop";
    }
    
    void StopTimer()
    {
        timer1.Enabled = false;
        button1.Text = "Start";
    }
