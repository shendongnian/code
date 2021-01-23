	private async void button1_Click(object sender, EventArgs e)
	{
		Task task = await Task.Factory.StartNew(() => startDownload("http://www.zwaldtransport.com/images/placeholders/placeholder1.jpg", "" + "sd.jpg"));
	}
	private async Task startDownload(string link, string savePath)
	{
		WebClient client = new WebClient();
		client.DownloadProgressChanged += Client_DownloadProgressChanged;
		client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
		await client.DownloadFileTaskAsync(new Uri(link), savePath);
	}
	private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
	{
                checkVersion();
		Console.WriteLine("Done, unless error or cancelled.");
	}
	private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
	{
		Console.WriteLine("Progress changed.");
	}
