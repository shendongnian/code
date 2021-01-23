    public async Task ExecuteAsync()
    {
        this.OnDownloadStarted(new ProgressEventArgs(0, HosterName));
		var httpClient = new HttpClient();
        var request = (HttpWebRequest)WebRequest.Create(this.HosterUrl);
        if (this.BytesToDownload.HasValue)
        {
            request.AddRange(0, this.BytesToDownload.Value - 1);
        }
        try
        {
            request.Timeout = 100000;
            request.ReadWriteTimeout = 100000;
            request.ContinueTimeout = 100000;
			
			var response = await httpClient.SendAsync(request);
			var responseStream = await response.Content.ReadAsStreamAsync();
			
			using (FileStream target = File.Open(this.SavePath, FileMode.Create, FileAccess.Write))
			{
				var buffer = new byte[1024];
				bool cancel = false;
				int bytes;
				int copiedBytes = 0;
	
				while (!cancel && (bytes = await responseStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
				{
					target.Write(buffer, 0, bytes);
	
					copiedBytes += bytes;
	
					var eventArgs = new ProgressEventArgs((copiedBytes * 1.0 / response.ContentLength) * 100, HosterName);
	
					if (this.DownloadProgressChanged != null)
					{
						this.DownloadProgressChanged(this, eventArgs);
	
						if (eventArgs.Cancel)
						{
							cancel = true;
						}
					}
				}
			}
        }
        
        catch (WebException ex)
        {
            if (ex.Status == WebExceptionStatus.Timeout)
        }
        this.OnDownloadFinished(new ProgressEventArgs(100, HosterName));
	}
