    private void CreatePlaylist(ObservableCollection<Collection> TrackCollection)
    {
    	// Make a new list
    	MPL = new MediaPlaybackList();
        foreach (var item in TrackCollection)
        {
            MediaSource ms = MediaSource.CreateFromUri(new Uri(item.origin.uri));
            ms.CustomProperties.Add("Title", item.origin.title);
            ms.CustomProperties.Add("Artist", item.origin.user.username);
            MPL.Items.Add(new MediaPlaybackItem(ms));
        }
    
        BackgroundMediaPlayer.Current.Source = MPL;
    }
