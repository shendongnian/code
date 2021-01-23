    var artist = new Artist }
       Name = "Offspring",
       Genres = new List<Genre> { rockGenre, punkGenre }
    };
    db.Artists.Add(artist);
    db.Entry(rockGenre).State = EntityState.Unchanged;
    db.Entry(punkGenre).State = EntityState.Unchanged;
    db.SaveChanges();
