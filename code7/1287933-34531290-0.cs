    public IEnumerable<T> GetAlbums()
    {
        using(dbContext db = new dbContext())
        { 
            IQueryable<T> query = db.Albums.GroupBy(a => a.SingerId)
                                            .Select(g => new 
                                            {
                                                SingerID = g.Key,
                                                Albums = g.Select(a => new { a.AlbumName, a.AlbumDate })
                                            });
        }
    }
