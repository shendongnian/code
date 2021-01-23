    public class Dao<T> : where T:class {
        internal virtual DbSet<T> EntitySet {
            get {
                return DB.Set<T>();
            }
        }
        public void DeleteById(int id) {
            T instance = FindById(id);
            Delete(instance);
        }
 
        public void Update(T instance) {
            DB.Entry(instance).State = EntityState.Modified;
            DB.SaveChanges();
        }
    }
