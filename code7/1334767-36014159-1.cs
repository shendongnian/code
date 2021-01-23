    public interface IRepository
    {
         // Your method operation.
    }
    
    public interface IFactory : IRepositoryFactory
    {
         // Container factory, to interject between multiple data context.
    }
    
    public interface IRepositoryFactory
    {
         IRepository Create();
    }
    
    public class DataContext : DbContext, IRepository
    {
         // Entity Framework and Repository concreete implementation.
    }
    
    public class DataContextFactory : IFactory
    {
         public IRepository Create()
         {
             return new DataContext();
         }
    }
