    private void Wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
    {
        if (e.Error == null) 
        {
            string resultFile = Path.Combine(insLoc, "update.zip");
            System.IO.File.WriteAllBytes(resultFile, e.Result);
            MessageBox.Show("Download success");
        }
        else 
        {
            MessageBox.Show("Download failed"); 
        }
    }
