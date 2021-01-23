    static class Program
    {
    	[STAThread]
    	static void Main()
    	{
    		Application.EnableVisualStyles();
    		Application.SetCompatibleTextRenderingDefault(false);
    		Application.Run(MainForm = new MyAppForm());
    	}
        public static MyAppForm MainForm { get; private set; }
    }
