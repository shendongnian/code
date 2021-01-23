	using (System.Net.WebClient client = new System.Net.WebClient())
	{
		client.DownloadProgressChanged += WebClient_DownloadProgressChanged;
		
		client.DownloadFile(sourceUrl, targetFile);
        client.DownloadProgressChanged -= WebClient_DownloadProgressChanged;
	}
	
	private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
	{
		// e.BytesReceived, 
        // e.TotalBytesToReceive,
	}
