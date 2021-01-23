    private async void CreatePlaybackList(IEnumerable<SongModel> songs)
    {
        // Make a new list and enable looping
        playbackList = new MediaPlaybackList();
        playbackList.AutoRepeatEnabled = true;
    
        // Add playback items to the list
        foreach (var song in songs)
        {
            MediaSource source;
            //Replace Ring 1 to the song we select
            if (song.Title.Equals("Ring 1"))
            {
                var file = await Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.GetFileAsync(ApplicationData.Current.LocalSettings.Values["song1"].ToString());
                source = MediaSource.CreateFromStorageFile(file);
            }
            else
            {
                source = MediaSource.CreateFromUri(song.MediaUri);
            }
            source.CustomProperties[TrackIdKey] = song.MediaUri;
            source.CustomProperties[TitleKey] = song.Title;
            source.CustomProperties[AlbumArtKey] = song.AlbumArtUri;
            playbackList.Items.Add(new MediaPlaybackItem(source));
        }
    
        // Don't auto start
        BackgroundMediaPlayer.Current.AutoPlay = false;
    
        // Assign the list to the player
        BackgroundMediaPlayer.Current.Source = playbackList;
    
        // Add handler for future playlist item changes
        playbackList.CurrentItemChanged += PlaybackList_CurrentItemChanged;
    }
