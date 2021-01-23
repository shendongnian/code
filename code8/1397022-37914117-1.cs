    string[] songs = new string[] { "song1", "song2", "song3", "song4" };       
    int numberOfSongs = songs.Count();
    var collection = songs.Select(x => x.ToString()); ;
    for (int i = 1; i < numberOfSongs; i++)
    {
        collection = collection.SelectMany(x => songs, (x, y) => x + "," + y);                            
    }
    List<string> SongCollections = new List<string>();
    SongCollections.AddRange(collection.Where(x => x.Split(',')
                                       .Distinct()
                                       .Count() == numberOfSongs)
                                       .ToList());
