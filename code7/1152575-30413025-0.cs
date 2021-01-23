    public static Response<Person> GetById(int id, IIncludeConfiguration<Person> includeConfiguration = null)
    {
        var output = new Response<Person>();
    
        using (var dbContext = new SmartDataContext())
        {
            dbContext.Configuration.ProxyCreationEnabled = false;
            var query = dbContext.EntityMasters.OfType<Person>();
    
            if(includeConfiguration != null)
            {
                query = includeConfiguration.ApplyIncludes(query);
            }
    
            output.Entity = query.FirstOrDefault(e => e.EntityId == id);
        }
    
        return output;
    }
    public interface IIncludeConfiguration<TEntity> where TEntity : class;
    {
        IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query)
    }
    public class PersonIncludeConfiguration : IIncludeConfiguration<Person>
    {
        public bool IncludeFiles {get;set;}
        public bool IncludeAddresses {get;set;}
        ....
    
        public IQueryable<Person> ApplyIncludes(IQueryable<Person> query)
        {
            if(IncludeFiles) query = query.Include(x => x.FileMasters);
            if(IncludeAddresses) query = query.Include(x => x.Addresses);
            ....
            return query;
        }
    GetById(1234, new PersonIncludeConfiguration{IncludeFiles = true});
