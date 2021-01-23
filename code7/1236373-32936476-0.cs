    public class Album : Master
        public override void Add(Album item)
        {
            db.Albums.Add(item);
            db.SaveChanges();
        }
    }
