	static class UIThread
	{
		private static Dispatcher _dispatcher;
		public static void Start()
		{
			using(var wh = new ManualResetEvent(false))
			{
				var thread = new Thread(ThreadProc)
				{
					IsBackground = true,
				};
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start(wh);
				wh.WaitOne();
			}
		}
		private static void ThreadProc(object arg)
		{
			var wh = (EventWaitHandle)arg;
			_dispatcher = Dispatcher.CurrentDispatcher;
			wh.Set();
			Dispatcher.Run();
		}
		public static Dispatcher Dispatcher
		{
			get { return _dispatcher; }
		}
	}
