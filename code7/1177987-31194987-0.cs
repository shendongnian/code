	public MainWindow()
	{
		InitializeComponent();
		this.ContentRendered+= Window_ContentRendered;
	}
	private void Window_ContentRendered(object sender, RoutedEventArgs e)
	{
		OpenProjectsView();
	}
