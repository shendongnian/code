    public static void Main()
    { 
        System.Windows.Forms.Timer timer;  //Declared in your 'Form.Designer.cs'
        timer.Interval = 1000; //Equals the 1 second
        timer.Start(); //Always use 'Timer.Stop', when you need stoping the Timer
        timer.Enabled = true;
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        pictureBox.Visible = !pictureBox.Visible;
    }
