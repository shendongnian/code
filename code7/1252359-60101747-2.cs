    public class DataRepository : IDataRepository
    {
        private bool disposing;
        private readonly MyDbContext context;
        public virtual void Dispose()
        {
            if (disposing)
            {
                return;
            }
            disposing = true;
            if (context != null)
            {
                context.Dispose();
            }
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public DataRepository()
        {
            context = new MyDbContext();
            context.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<MyDbSet> GetMyDbSet()
        {
            return context.MyDbSet;
        }
    }
