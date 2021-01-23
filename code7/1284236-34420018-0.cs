    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.MouseMove += MainWindow_MouseMove;
		}
		void MainWindow_MouseMove(object sender, MouseEventArgs e)
		{
			Console.WriteLine("Mouse moved");
		}
    }
