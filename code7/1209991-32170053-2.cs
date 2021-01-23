    private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Error == null) 
        {
            MessageBox.Show("Download success");
        }
        else 
        { 
            MessageBox.Show("Download failed"); 
        }
    }
