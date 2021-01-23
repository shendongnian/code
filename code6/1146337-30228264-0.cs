    private void wzProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(() => wzProgressChanged(sender, e));
        }
        else if (sw.Elapsed.TotalSeconds > 0)
        {
            try
            {
                statusContent.Text = "Downloading new game files";
                downloadInfo.Text = "Downloading: " + string.Format("{0} MB / {1} MB", (e.BytesReceived / 1024d / 1024d).ToString("0.00"), (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00")) + " with " + string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00")) + " (" + e.ProgressPercentage.ToString() + "%" + ")";
                progressBar1.Value = e.ProgressPercentage;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
