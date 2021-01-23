    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        aTimer = new System.Timers.Timer(1000);
        aTimer.Elapsed += aTimer_Elapsed;
        aTimer.Interval = 1000;
        aTimer.Enabled = true;
        Application.Run(new Form1());
    }
