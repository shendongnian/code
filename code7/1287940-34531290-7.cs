    public IEnumerable<T> GetAlbums()
    {
        using(dbContext db = new dbContext())
        { 
            IQueryable<T> query = from a in db.Albums
                                  group a by a.SingerID into albums
                                  select new 
                                  {
                                      SingerID = albums.Key,
                                      Albums = albums.Select(album => new { album.AlbumName, album.AlbumDate })
                                  };
        }
    }
