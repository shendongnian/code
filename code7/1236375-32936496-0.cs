    public class Master<T>
    {
        MusicStoreEntities db = new MusicStoreEntities();
        public void Add(T item)
        {
            db.Set<T>().Add(item);
            db.SaveChanges();
        }
    }
    
    public class AlbumRepository : Master<Album> { }
    public class ArtistRepository : Master<Artist> { }
  
