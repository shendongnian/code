    public class GameDB
    {
        private TBCDBEntities db;
        public GameDB()
        {
            db = new TBCDBEntities();
        }
        public void Update(game g)
        {
            db.Entry(g).State = EntityState.Modified;            
        }
        public void Save()
        {
            db.SaveChanges();
        }
