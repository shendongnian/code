	class BackgroundWorkerExample 
	{
		private BackgroundWorker _backgroundWorker;
		public Program()
		{
			_backgroundWorker = new BackgroundWorker();
			_backgroundWorker.DoWork += BackgroundWorker_DoWork;
			_backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			_backgroundWorker.RunWorkerAsync();
		}
		private static void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			//some selenium code to tests something 
		}
		private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//Whatever you want to do when the tests complete
		}
	}
