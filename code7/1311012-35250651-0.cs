	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{ 
			Point[] curvePoints =
			{
				new Point(10, 10),
				new Point(13, 11),
				new Point(15, 30),
				new Point(17, 10),
				new Point(20, 10),
				new Point(30, 15),
				new Point(30, 30),
				new Point(60, 40),
				new Point(65, 55),
				new Point(40, 60),
				new Point(40, 65),
				new Point(58, 70),
				new Point(60, 60),
				new Point(90, 60),
				new Point(90, 85),
				new Point(70, 61),
				new Point(60, 85),
				new Point(30, 85),
				new Point(12, 80),
				new Point(12, 78),
				new Point(16, 75),
				new Point(13, 68),
				new Point(17, 65),
				new Point(6, 62),
				new Point(16, 60),
				new Point(28, 56),
				new Point(27, 45),
				new Point(15, 32),
				new Point(15, 50),
				new Point(5, 50),
				new Point(10, 40)
			};
			var pointCollection = new PointCollection(curvePoints);
			var polygon = new Polygon
			{
				Stroke = Brushes.GreenYellow,
				StrokeThickness = 1,
				Fill = Brushes.Blue,
				Points = pointCollection
			};
			const int cx = 800;
			const int cy = 600;
			polygon.Measure(new Size(cx, cy)); 
			polygon.Arrange(new Rect(0, 0, cx, cy)); 
			RenderTargetBitmap bmp = new RenderTargetBitmap(cx, cy, 120, 96, PixelFormats.Pbgra32);
			bmp.Render(polygon);
			_image.Source = bmp;
		}
	}
