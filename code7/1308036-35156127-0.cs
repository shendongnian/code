    var artist = new Artist }
       Name = "Offspring",
       Genres = new List<Genre> { rockGenre, punkGenre }
    };
    db.Artists.Add(artist);
    db.SaveChanges();
