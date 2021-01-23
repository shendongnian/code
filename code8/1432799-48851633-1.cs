    public interface IDbContext
    {
        int SaveChanges();
    }
    
    
    public interface IDbSet<TE, in TId>
    {
        TE Add();
        IQueryable<TE> All();
        TE Get(TId id);
        void Delete(TId id);
    }
