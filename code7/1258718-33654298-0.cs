    public class Repository : IRepository
    {
        private Context _db = new Context();
        private Type entityType;
        public Repository (Type entityType)
        {
            this.entityType= entityType;
        }
        public object Add(object newItem) 
        {
            var result = _db.Set(entityType).Add(newItem);
            _db.SaveChanges();
            return result;
        }
    }
