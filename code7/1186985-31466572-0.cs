    public interface IGenericRepository
    {
        void AddObjectAsync<T>(T entity) where T : class;
    }
    public class GenericRepository : IGenericRepository
    {
        private readonly DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context;
        }
        
        ....
        public async void AddObjectAsync<T>(T entity) where T : class
        {
            // Validate that that there is not an existing object in the database.
            var x = _context.Entry(entity);
            if (!Exists(entity))
            {
                _context.Set<T>().Add(entity); // Add the entry if it does not exist.
                _context.SaveChanges();
            }
            else
            {
                UpdateObjectAsync(entity); // Update the entry if it did exist.
            }
        }
    }
    public interface IComponentRepository
    {
        void AddComponentAsync(Component component);
        // or void AddComponentAsync<T>(T component);
        // depends if you'll be reusing the ComponentRepository 
        // for types that inherit Component but still have individual tables... 
        // It was a little difficult to tell from your example.
    }
    public class ComponentRepository : GenericRepository, IComponentRepository
    {
        public ComponentRepository(DbContext context) : base(context) { }
        ...
        public async void AddComponentAsync(Component component)
        {
            try
            {
                if (component == null) throw new ArgumentNullException();
                AddObjectAsync(component);
            }
            catch (ArgumentNullException ex)
            {
                _logger.WriteErrorLogAsync(ex);
                throw ex;
            }
        }
    }
