    private async void frm_HosterDownloader_Load(object sender, EventArgs e)
    {
    	await Task.Delay(5000);
    	await StartDownloadAsync();
    }
    
    private async Task StartDownloadAsync()
    {
        int counter = 0;
        Dictionary<string, string> hosters = Hosters.GetAllHostersUrls();
    
        progressBar_Download.Maximum = hosters.Count * 100;
        progressBar_Download.Minimum = 0;
        progressBar_Download.Value = 0;
    	
    	var downloadTasks = hosters.Select(hoster => 
    	{
    		lbl_FileName.Text = hoster.Key;
            lbl_NumberOfDownloads.Text = (++counter).ToString() + "/" + hosters.Count().ToString();
    		
    		Downloader downloader = new Downloader(host.Value, string.Format(HostersImagesFolder + @"\{0}.png", IllegalChars(host.Key)));
    		downloader.HosterName = host.Key;
    		downloader.DownloadFinished += downloader_DownloadFinished;
    		
    		downloader.ExecuteAsync(); 
    	});
    	
    	await Task.WhenAll(downloadTasks);
    }
