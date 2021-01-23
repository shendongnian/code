	public static string fileOpen;
	public static string workingDirectory;
	public MainWindow()
	{
		InitializeComponent();
		Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
		// This sets the directory back to the program directory, so you can do what you need
		// to with files associated with your program
	}
	// Make sure your MainWindow has an OnLoaded event assigned to:
	private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
	{
		// Now I'm setting the working directory back to the file location
		Directory.SetCurrentDirectory(workingDirectory);
		if (File.Exists(fileOpen))
		{
			var path = Path.GetFullPath(fileOpen);
			// This should be the full file path of the file you clicked on.
		}
	}
