    using (var scope = new TransactionScope())
    {
        repo1.SaveChanges();
        repo2.SaveChanges();   
        scope.Complete();
    } 
    public class AggregateRepository
    {
        private readonly Dictionary<Type, IRepository> repositories;
        public AggregateRepository()
        {
            //... initialize repositories here ...
        }
        public void Add<T>(T entity)
        {
            repositories[typeof(T)].Add(entity);
            // mark repositories[typeof(T)] somehow
        }
        public void SaveChanges()
        {
            using (var scope = new TransactionScope())
            {
               foreach(markedRepository)
               {
                  markedRepository.SaveChanges();  
               }
               scope.Complete();
            }
        } 
