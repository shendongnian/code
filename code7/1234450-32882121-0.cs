    IEnumerable<string> genres = xSongs
        .Elements("Song")
        .SelectMany(song => song
            .Element("Genres")
            .Elements("Genre")
            .Select(genre => genre.Value));
