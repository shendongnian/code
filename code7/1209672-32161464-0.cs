    private async void StartButton_Click(object sender, RoutedEventArgs e)
    {
        DownloadGameFile dlg = new DownloadGameFile();
        await dlg.StartDownload(11825);
    }
