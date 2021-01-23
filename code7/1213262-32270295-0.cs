    Task<bool> DownloadArchiveAsync( string fileUrl )
    {
        return Task<bool>.Factory.StartNew( () =>
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
                var signalCompleted = new System.Threading.ManualResetEventSlim();
                AsyncCompletedEventHandler AsyncCompletedEvent = ( s, e ) =>
                {
                    signalCompleted.Set();
                };
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadProgressChanged += DownloadProgressChangedEvent;
                    webClient.DownloadFileCompleted += AsyncCompletedEvent;
                    webClient.DownloadFileAsync( downloadLink, saveFilename );
                }
                signalCompleted.Wait();
                return true;
            } );
    }
