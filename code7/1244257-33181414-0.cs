	static class Program
	{
	    public static event EventHandler CheckInventoryEvent;
	    /// <summary>
	    /// The main entry point for the application.
	    /// </summary>
	    [STAThread]
	    static void Main()
	    {
	        Application.EnableVisualStyles();
	        Application.SetCompatibleTextRenderingDefault(false);
	        System.Timers.Timer tmr = new System.Timers.Timer(300000); //Every 5 minutes
	        tmr.Elapsed += Tmr_Elapsed;
	        tmr.Start();
	        Application.Run(new MainForm());
	        tmr.Stop();
	    }
	    private static void Tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
	    {
	        OnCheckInventoryEvent();
	    }
	    public static void OnCheckInventoryEvent()
	    {
	        if (CheckInventoryEvent != null)
	            CheckInventoryEvent(null, EventArgs.Empty);
	    }
	}
