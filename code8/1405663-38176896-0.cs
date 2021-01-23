	wc.Encoding = Encoding.UTF8;
    wc.Proxy = new WebProxy(myProxy);
	string result = null;
	var waitCancel = new CancellationTokenSource();
	wc.DownloadStringCompleted += (sender, e) =>
	{
		if (e.Cancelled) return;
		waitCancel.Cancel();
		result = e.Result;
	};
	wc.DownloadStringAsync(url);
	waitCancel.Token.WaitHandle.WaitOne(30 * 1000);
	if (waitCancel.IsCancellationRequested == false)
	{
		wc.CancelAsync();
	}
	Console.WriteLine("Result: " + result);
