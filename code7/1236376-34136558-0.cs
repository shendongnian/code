     public abstract class RepositoryBase<T>:IRepository<T> where T:class
    {
        public void Add(T item)
        {
            db.Set<T>().Add(item);
            db.SaveChanges();
        }
        public void Update(int id,T item)
        {
            db.Entry(db.Set<T>().Find(id)).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
        public void Delete(T item)
        {
            db.Set<T>().Remove(item);
            db.SaveChanges();
        }
        public List<T> SelectAll()
        {
            return db.Set<T>().ToList();
        }
        public T SelectByID(int id)
        {
            return db.Set<T>().Find(id);
        }
    }
