    void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        label2.Content = string.Format("Downloaded {0}kb of {1}kb ({2}%)", e.BytesReceived / 1000, e.TotalBytesToReceive / 1000, e.ProgressPercentage);
        progressBar1.Value = e.ProgressPercentage;
        int c = e.ProgressPercentage * 255 / 100;
        // unused, but this would be how you'd get it
        // Color myColor = Color.FromArgb(255, (byte)c, (byte)(255 - c), 0);
        string hex = string.Format("FF{0:X2}{1:X2}00", c, 255 - c);
        Console.WriteLine(hex);
    }
