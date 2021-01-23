    public static IRepository<T> GetRepositoryInstance<T, TRepository>(params object[] args)
        where TRepository : IRepository<T>
        where T : class
        {
            return (TRepository)Activator.CreateInstance(typeof(TRepository), args);
        }
