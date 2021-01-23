    public class RepositoryFactory : IRepositoryFactory
    {
            public IRepository<T> CreateRepository<T>() where T : class
            {
                var yourContext = new SomeContext(); //can also be injected
                return new Repository<T>(yourContext);
            }
    }
