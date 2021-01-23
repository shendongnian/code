    private async void LoadUploadsListAsync()
    {
    	try
    	{
    		var progress = new Progress<string>(text => this.listBox1.Items.Add(text));
            await RetrieveUploadsListAsync(progress);
    		if (this.listBox1.Items.Count > 0)
    		{
    			this.listBox1.SelectedIndex = 0;
    			axWindowsMediaPlayer1.URL = videosUrl[0];
    		}
    	}
    	catch (TaskCanceledException)
    	{    
    	}
    	catch (Exception ex)
    	{
    	}
    }
