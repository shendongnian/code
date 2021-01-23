    var playbackList = new MediaPlaybackList();
    playbackList.AutoRepeatEnabled = true;
    mediaElement.SetPlaybackSource(playbackList);
    
    await Task.Run(async () =>
    {
        for (int i = 0; i < songs.Count(); i++)
        {
            var song = songs.ElementAt(i);
    
            var source = MediaSource.CreateFromStorageFile(await StorageFile.GetFileFromPathAsync(song.File));
            source.CustomProperties["TrackIdKey"] = null;
            source.CustomProperties["TitleKey"] = song.Title;
            source.CustomProperties["AlbumArtKey"] = song.AlbumArtUri;
            source.CustomProperties["AuthorKey"] = song.Author;
            source.CustomProperties["TrackNumber"] = (uint)(i + 1);
            playbackList.Items.Add(new MediaPlaybackItem(source));
            Debug.WriteLine($"[{i}] {song.Title} added to playlist");
        }
    });
