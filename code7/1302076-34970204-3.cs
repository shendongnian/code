	public partial class MainWindow : Window
	{
		private readonly BackgroundWorker _worker;
		public MainWindow()
		{
			InitializeComponent();
			_worker = new BackgroundWorker();
			_worker.DoWork += worker_DoWork;
		}
		private void Run_Click(object sender, RoutedEventArgs e)
		{	
			_worker.RunWorkerAsync();
		}
		private void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			//here is your time consuming task 
			for (int i = 0; i < 5000; i++)
			{
				Console.WriteLine(i + "Hello World");
			}
		}
	}
