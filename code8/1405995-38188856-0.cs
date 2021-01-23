    System.Windows.Forms.Timer textTimer;
    private void Form1_Load(Object sender, EventArgs e)
    {
        textTimer = new System.Windows.Forms.Timer();
        textTimer.Interval = 300;
        textTimer.Tick += new EventHandler(textTimer_Tick);
    }
    private void textTimer_Tick(Object sender, EventArgs e)
    {
        if (textSearchString.Focused) {
            populateGrid();
            textTimer.Stop(); //No disposing required, just stop the timer.
        }
    }
    private void textSearchString_TextChanged(object sender, EventArgs e)
    {
        textTimer.Start();
    }
