    async Task<bool> DownloadArchiveAsync( string fileUrl )
    {
        var downloadLink = new Uri( fileUrl );
        var saveFilename = System.IO.Path.GetFileName( downloadLink.AbsolutePath );
        DownloadProgressChangedEventHandler DownloadProgressChangedEvent = ( s, e ) =>
        {
            progressBar.BeginInvoke( (Action)(() =>
            {
                progressBar.Value = e.ProgressPercentage;
            }) );
            var downloadProgress = string.Format( "{0} MB / {1} MB",
                    (e.BytesReceived / 1024d / 1024d).ToString( "0.00" ),
                    (e.TotalBytesToReceive / 1024d / 1024d).ToString( "0.00" ) );
            statusLabel.BeginInvoke( (Action)(() =>
            {
                statusLabel.Text = "Downloading " + downloadProgress + " ...";
            }) );
        };
        using (WebClient webClient = new WebClient())
        {
            webClient.DownloadProgressChanged += DownloadProgressChangedEvent;
            await webClient.DownloadFileTaskAsync( downloadLink, saveFilename );
        }
        return true;
    }
