	private void MyMethodAsync()
	{
		// Note you should probably register only once, so this may not fit here.
		TaskScheduler.UnobservedTaskException += (s, e) => GlobalLogger.Log(e);
		Task t = Task.Run(() =>
		{
			// Do some staff
		}).ContinueWith(MyContinueWith);
	}
	
