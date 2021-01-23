    while (true)
	{
		cached_secondsElapsed = secondsElapsed;
		cached_currentFileSizeDownloaded = currentFileSizeDownloaded;
		Thread.Sleep(10000); // Sleep 10 seconds
		long bytesDownloaded = currentFileSizeDownloaded - cached_currentFileSizeDownloaded;
		double secondsItTook = secondsElapsed - cached_secondsElapsed;
		if (bytesDownloaded > 0)
		{
			double downloadSpeed = ((double)bytesDownloaded / secondsItTook); // bytes per second
			long remainingTime = (totalFileSizeToDownload - currentFileSizeDownloaded) / (long)downloadSpeed;
			Console.WriteLine("Download speed {0}", Formatting.FormatBytes((long)downloadSpeed));
			Console.WriteLine("Remaining time {0}", Formatting.FormatSeconds(remainingTime));
			Console.WriteLine();
		}
		else
		{
			Console.WriteLine("bytesDownloaded = 0"); // DEBUG
			Application.Exit(); // Stop the app
		} 
	}
