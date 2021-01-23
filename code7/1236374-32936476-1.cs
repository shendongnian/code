    public interface IMasterRepository 
    {
        public void Add(Master item);
    }
    public class AlbumRepository : IMasterRepository
        public override void Add(Album item)
        {
            db.Albums.Add(item);
            db.SaveChanges();
        }
    }
