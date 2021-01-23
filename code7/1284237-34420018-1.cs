    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.MouseMove += Window_MouseMove;
		}
		private void Window_MouseMove(object sender, MouseEventArgs e)
		{
			Console.WriteLine("Mouse moved");
		}
    }
