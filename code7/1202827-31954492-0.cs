    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        StorageFolder musicLib = Windows.Storage.KnownFolders.MusicLibrary;
        StorageFile song = await musicLib.GetFileAsync(@"Artist\Album\Song.mp3");
        var stream = await song.OpenReadAsync();
        me.SetSource(stream, stream.ContentType);
    }
