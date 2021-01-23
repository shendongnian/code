    public IEnumerable<AlbumMapper> GetAlbums()
    {
        using(dbContext db = new dbContext())
        { 
            return db.Albums.GroupBy(a => a.SingerID)
                            .Select(g => new AlbumMapper
                            {
                                SingerID = g.Key,
                                Albums = g.Select(a => new AlbumDetails { AlbumName = a.AlbumName, AlbumDate = a.AlbumDate })
                            });
        }
    }
