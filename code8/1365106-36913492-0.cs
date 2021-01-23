	public class Worker
	{
		private BackgroundWorker _worker;
		private AutoResetEvent _event;
		private Func<bool> _action;
		
		public Worker(Func<bool> action)
		{
			_action = action;
			_event = new AutoResetEvent(false);
			_worker = new BackgroundWorker();
			_worker.DoWork += (sender, e) => 
			{
				try
				{
					e.Result = _action();
				}
				finally
				{
					_event.Set();
				}
			};
			_worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
		}
		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Console.WriteLine("Thread completed : "+ e.Result.ToString());
		}
		public void DoWork()
		{
			Console.WriteLine("worker thread: working...");
			_worker.RunWorkerAsync();
			_event.WaitOne();
		}
	}
