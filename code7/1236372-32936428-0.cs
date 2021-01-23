    namespace MusicStoreApp.BLL.Master
    {
        public abstract class Master<T>
        {
            MusicStoreEntities db = new MusicStoreEntities();
            public void Add(T item)
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }
    }
