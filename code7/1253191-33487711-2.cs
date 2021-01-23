    public class Saver : IDisposable
    {
        private readonly AuraEntities db;
        private bool disposed;
        public Saver()
        {
            db = new AuraEntities();
            disposed = false;
        }
        public int SaveCensusBatch(string key, ICollection<tbl_Life_Census> collection)
        {
           var entry = new tbl_Life_Master() { UUID = key, tbl_Life_Census = collection };
           db.tbl_Life_Master.Add(entry);
           return 1;
       }
    
        public int SaveLifeData(string key2, ICollection<tbl_Life_General_Info> collection)
        {
           var entry = new tbl_Life_Master() { UUID = key2, tbl_Life_General_Info = collection };
           db.tbl_Life_Master.Add(entry);
           return 1;
        }
        public T GetDBRecordByPK<T>(string key) where T : class
        {
            var t = db.Set<T>().Find(key);
            return t;
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing && db != null)
            {
                db.Dispose();
                disposed = true;
            }
        }
    }
