    public abstract class RepositoryBase : IDisposable, IRepository
    {
        public virtual IDbConnectionFactory DbFactory { get; set; }
        IDbConnection db;
        public virtual IDbConnection Db
        {
            get { return db ?? (db = DbFactory.OpenDbConnection()); }
        }
        public virtual void Dispose()
        {
            if (db != null)
                db.Dispose();
        }
    }
