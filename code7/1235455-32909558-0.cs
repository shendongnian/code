	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MyContext());
		}
	}
	public class MyContext : ApplicationContext
	{
		public MyContext()
		{
			// this is the new "entry point" for your application
			
			// use Application.Exit() to shut down the application
			
			// you can still create and display a NotifyIcon control via code for display in the tray
			// (the icon for the NotifyIcon can be an embedded resource)
			// you can also display forms as usual when necessary
		}
	}
