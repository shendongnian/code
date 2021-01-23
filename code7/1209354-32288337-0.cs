	WebClient Get = new WebClient();
	// identify your self as a web browser
	Get.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
	Uri uri = Uri("http://asap.eb2a.com/a.text");
	string contentToShow = String.Empty;
	// timer for the repetitive task called every nnn milliseconds
	const long refreshIntervalInMilliseconds = 100;
	System.Timers.Timer timer = new System.Timers.Timer(refreshIntervalInMilliseconds);
	timer.Elapsed += (s, e) =>
	{
		Console.WriteLine(String.Format("{0} Fetching data from: {1}", DateTime.Now, uri));
		try
		{	        
			var result = Get.DownloadString(uri);
			if (result != contentToShow)
			{
				contentToShow = result;
				notifyIcon1.Visible = true;
				notifyIcon1.BalloonTipText = contentToShow;
				notifyIcon1.BalloonTipTitle = "We Notify You";
				notifyIcon1.ShowBalloonTip(150);
			}
		}
		catch (Exception exception)
		{
			MessageBox.Show(string.Format("Error: {0}", exception.Message));
		}
	};
	// start the timer
	timer.Start();
