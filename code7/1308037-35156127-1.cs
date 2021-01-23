    db.Genres.Attach(rockGenre);
    db.Genres.Attach(punkGenre);
    var artist = new Artist { Name = "Offspring" };
    db.Artists.Add(artist);
    artist.Genres = new List<Genre> { rockGenre, punkGenre };
    db.SaveChanges();
