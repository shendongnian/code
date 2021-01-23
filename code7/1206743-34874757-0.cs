		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			string nomeFile = @"\EW.accde";
			string DestinationPath;
			string codeBase = Assembly.GetExecutingAssembly().CodeBase;
			UriBuilder uri = new UriBuilder(codeBase);
			string path = Uri.UnescapeDataString(uri.Path);
			DestinationPath = System.IO.Path.GetDirectoryName(path) + @"\Resources";
			Process.Start(DestinationPath + nomeFile);
		}
