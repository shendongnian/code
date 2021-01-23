    IEnumerable<string> genres = xSongs.Elements("Song")
        .Select(song => song.Element("Genres"))
        .SelectMany(genres => genres.Elements("Genre"))
        .Select(genre => genre.Value)
        .OrderBy(x => x);
