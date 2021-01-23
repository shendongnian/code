	private void WebClientOnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
	{
		if (e.Cancelled)
		{
			//Delete the file in here
			MessageBox.Show("Download cancelled!");
			File.Delete(@"path\to\partially\downloaded\file");
			this.Close(); 
		}
		else
		{
			MessageBox.Show("Download succeeded!"); // Works
		}
	}
	private void Form1_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (_web_client.IsBusy)
		{
			e.Cancel = true;
			if (this._web_client != null)
			{
				this._web_client.CancelAsync();
			}
		}		
	}
