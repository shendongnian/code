    public abstract class BaseRepository<C, T> : IBaseRepository<T>
        where T : class
        where C : DbContext, new()
    {
    
        protected BaseRepository(C context)
        {
            _context = context;
            _context.Database.Log = message => Trace.WriteLine(message);
        }
    
        //snip
    }
