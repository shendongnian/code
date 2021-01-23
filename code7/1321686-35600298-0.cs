    private void Timer()//Timer for color refresh
    {
        aTimer = new System.Timers.Timer(300);
        aTimer.Elapsed += ATimer_Elapsed;//new ElapsedEventHandler(Form1_Load);
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }
    private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        RefreshColor();
    }
    private void RefreshColor()//Refreshing the color of selected row
    {
        this.Invoke((MethodInvoker)delegate
        {
            if (richTextBox1.SelectionBackColor != Color.PaleTurquoise)
            {
                HighlightCurrentLine();
            }
        });
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        Timer();
        RefreshColor();
