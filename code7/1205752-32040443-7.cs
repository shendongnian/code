	public partial class MainWindow : Window
	{
		ChatHandler chatHandler;
		BackgroundWorker worker;
		public MainWindow()
		{
			InitializeComponent();
			chatHandler = new ChatHandler();
			worker = new BackgroundWorker();
			worker.WorkerSupportsCancellation = true;
			worker.DoWork += new DoWorkEventHandler(run);
		}
		private void write(string text)
		{
			if (chat.Text != text && text != "")
			{
				chat.Text = text;
			}
		}
		private void run(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker bg = sender as BackgroundWorker;
			while (!bg.CancellationPending)
			{
				chat.Dispatcher.BeginInvoke((Action)(() => {
					write(chatHandler.Read());
				}));
				Thread.Sleep(100);
			}
		}
		private void chat_Loaded(object sender, RoutedEventArgs e)
		{
			if (!worker.CancellationPending)
			{
				worker.RunWorkerAsync();
			}
		}
		private void chat_Unloaded(object sender, RoutedEventArgs e)
		{
			worker.CancelAsync();
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			chatHandler.Write(chatWriter.Text);
		}
	}
