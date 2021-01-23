    protected IDbContext _context;
    public GenericDao(IDbContext dbContext)
    {
        this._context = dbContext;
    }
    public void Remove(TDomain domain)
    {
        _context.Remove(this.ToEntity(domain));
    }
    //abstraction
    public interface IDbContext
    {
        void Remove(Entity entity);
    }
    //EF Implementation
    public MyEfClass : IDbContext
    {
        public void Remove(Entity entity)
        {
            //code to remove for EF example
            context.Attach(entity);
            context.State = EntityState.Modified;
            context.Set<TEntity>.Remove(entity);
            context.SaveChanges();
        }
 
    }
    
    //WCF Implementation
    public MyWCFClass : IDbContext
    {
        public void Remove(Entity entity)
        {
            //Wcf implementation here
        }
    }
    //File example 
    public FileWriter : IDbContext
    {
        public void Remove(Entity entity)
        {
            LoadFile();
            FindEntry(entity);
            WriteFile(entity);
            SaveFile();
        }
        public void LoadFile()
        {
              //use app settings for file directory
        }
    }
