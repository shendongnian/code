    private async void files()
    {
        var query = KnownFolders.MusicLibrary.CreateFileQuery();
        var allFiles = await query.GetFilesAsync();
        foreach (var f in allFiles)
        {
            listView.Items.Add(f);
        }
    }
