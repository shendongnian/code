    public Timer myTimer { get; set; }
    public Form()
    {
       myTimer = new Timer();
       myTimer.Tick += new EventHandler(TimerEventProcessor);
    }
    private void button1_Click(object sender, EventArgs e)
    {       
       myTimer.Interval = Convert.ToInt32(numericUpDown1.Value);
       myTimer.Start();
    }
    public void Form_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            myTimer.Stop();
            this.Close();
        }
    }
    private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
    {
        //Get x/y coordinates of mouse
        int X = Cursor.Position.X;
        int Y = Cursor.Position.Y;
        //Click mouse at x/y coordinates
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
    }
