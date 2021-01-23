     public class CountryRepository : GenericRepository<Country>, ICountryRepository
        {
    
            public CountryRepository(MainContext mainContext) : base(mainContext) { }
    
            public IEnumerable<Country> GetByLocation(float location)
            {
                return this.Context.Countries.ToList();
            }
.....
     public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
        {
            public MainContext Context { get; set; }
            public IDbSet<TEntity> DbSet { get; set; }
    
            public GenericRepository(MainContext context)
            {
                Context = context;
                DbSet = context.Set<TEntity>();
            }
