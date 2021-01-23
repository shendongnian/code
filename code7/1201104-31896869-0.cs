    private Timer _myTimer;
    private int number = 0;
    private void Form1_Load(object sender, EventArgs e)
    {
        _myTimer = new Timer();
        _myTimer.Interval = 1; // 1 millisecond
        _myTimer.Tick += new EventHandler(MyTimer_Tick);
        _myTimer.Start();
    }
    // increments the number at timer tick
    private void MyTimer_Tick(object sender, EventArgs e)
    {
        number ++;
        // TODO: update UI here
    }
    // Stops the timer
    private void button1_Click(object sender, EventArgs e)
    {
        _myTimer.Stop();
    } 
