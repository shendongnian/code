    private void DownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            XDocument xdoc = XDocument.Parse(e.Result);
    		var result = xml.Root;
    		btn.Content = result;
        }
    }
