	class State
	{
		public int X { get; set; }
		public string Str { get; set; }
		public DateTime Current { get; set; }
	}
	class Example
	{
		State state;
		CancellationTokenSource cts = new CancellationTokenSource();
		Object syncObj = new Object();
		Task updater;
		List<Task> readers = new List<Task>();
		public void Run()
		{
			updater = Task.Factory.StartNew(() =>
			{
				while (!cts.Token.IsCancellationRequested)
				{
					// wait until we have a new state from some source
					Thread.Sleep(1000);
					var newState = new State() { Current = DateTime.Now, X = DateTime.Now.Millisecond, Str = DateTime.Now.ToString() };
					// critical part
					lock(syncObj) {
						state = newState;
					}
				}
			}, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
			for (int i = 0; i < 10; i++)
			{
				readers.Add(Task.Factory.StartNew(() =>
				{
					while (!cts.Token.IsCancellationRequested)
					{
						State readState = null;
						// critical part
						lock(syncObj) {
							readState = state.Clone();
						}
						// use it
						if (readState != null)
						{
							Console.WriteLine(readState.Current);
							Console.WriteLine(readState.Str);
							Console.WriteLine(readState.X);
						}
					}
				}, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default));
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			new Example().Run();
			Console.ReadKey();
		}
	}
