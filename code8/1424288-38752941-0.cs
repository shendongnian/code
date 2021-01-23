        public interface IRepository<TEntity, in TKey> where TEntity : class
    {
       TEntity Get(TKey id);
    }
    public class SomeRepo1 : IRepository
    {
      private readonly FileDbContext someDbContext;
      
       public FileRepository(FileDbContext dbContext)
       {
          someDbContext = dbContext;
       }
       public File Get(string id)
       {
         return someDbContext.Files.ToList();
       }
    }
