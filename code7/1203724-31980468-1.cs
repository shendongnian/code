	class Startup
	{
		[STAThreadAttribute]
		public static int Main(string[] args)
		{
			if (args.Length == 0)
			{
				// run windowed
				App app = new App();
				app.InitializeComponent();
				app.Run();
			}
			else
			{
				// run console
				ConsoleManager.Show();
				Console.WriteLine("Press any key to exit...");
				Console.ReadKey();
			}
			return 0;
		}
	}
