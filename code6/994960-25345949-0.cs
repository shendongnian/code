    using(MediaLibrary library = new MediaLibrary())
    {
    foreach(var song in library.Songs)
    {
        Debug.WriteLine("Name: " + song.Name);
        Debug.WriteLine("Artist: " + song.Artist.Name);
        Debug.WriteLine("Album: " + song.Album.Name);
    }
    }
