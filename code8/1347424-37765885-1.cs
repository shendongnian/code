    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
    
        IReadOnlyList<StorageFile> files = await KnownFolders.RemovableDevices.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.OrderByName);
        var songs = new List<Song>();
        string root = $@"{Path.GetPathRoot(files.FirstOrDefault()?.Path)}Tracks\";
        foreach (StorageFile file in files)
            if (file.Path.StartsWith(root))
                songs.Add(new Song { File = file.Path, Title = Path.GetFileNameWithoutExtension(file.Path) });
    
        var playbackList = new MediaPlaybackList();
        playbackList.AutoRepeatEnabled = true;
        mediaElement.SetPlaybackSource(playbackList);
    
        await Task.Run(async () =>
        {
            for (int i = 0; i < songs.Count(); i++)
            {
                var song = songs.ElementAt(i);
                var source = MediaSource.CreateFromStorageFile(await KnownFolders.RemovableDevices.GetFileAsync(song.File));
                source.CustomProperties["TrackIdKey"] = null;
                source.CustomProperties["TitleKey"] = song.Title;
                source.CustomProperties["AlbumArtKey"] = song.AlbumArtUri;
                source.CustomProperties["AuthorKey"] = song.Author;
                source.CustomProperties["TrackNumber"] = (uint)(i + 1);
                playbackList.Items.Add(new MediaPlaybackItem(source));
                Debug.WriteLine($"[{i}] {song.Title} added to playlist");
            }
        });
    }
