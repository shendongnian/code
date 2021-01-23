	[Test]
	public void Test_window()
	{
        var showMonitor = new ManualResetEventSlim(false);
        var closeMonitor = new ManualResetEventSlim(false);
		Thread th = new Thread(new ThreadStart(delegate
		{
			var mw = new MainWindow();
			mw.Show();
			showMonitor.Set();
            closeMonitor.WaitOne();
		}));
		th.ApartmentState = ApartmentState.STA;
		th.Start();
		showMonitor.WaitOne();
		Task.Delay(1000).Wait();
        //anything you need to test
        closeMonitor.Set();
	}
