    public partial class ImageLayout : Window
	{
		public WindowProperties WindowProperties { get; set; }
		public ImageLayout()
		{
			WindowProperties = new WindowProperties();
			InitializeComponent();
		}
		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			WindowProperties.CurrentHeightChange = e.NewSize.Height / 768;
			WindowProperties.CurrentWidthChange = e.NewSize.Width / 1366;
		}
	}
