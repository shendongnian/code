    System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    myTimer.Tick += myTimer_Tick;
    void myTimer_Tick(object sender, EventArgs e)
    {
        Backup();
    }
