    Downlaod_Click()
    public static async void Downlaod_Click()
            {
                var cts = new CancellationTokenSource();
                Problem fileDownloaded = await MainHelper.DownloadFileFromWeb(new Uri(@"url", UriKind.Absolute), "myfile.mp3", cts.Token);
                switch (fileDownloaded)
                {
                    case Problem.Ok:
                        MessageBox.Show("File downloaded");
                        break;
                    case Problem.Cancelled:
                        MessageBox.Show("Download cancelled");
                        break;
                    case Problem.Other:
                    default:
                        MessageBox.Show("Other problem with download");
                        break;
                }
            }
