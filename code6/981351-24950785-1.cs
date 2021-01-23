    public class UnitOfWork : IUnitOfWork
    {
    	private static IContainer _container;
    	Hashtable _repositories = new Hashtable();
    	public static Module CurrentRepositoriesModule { get; set; }
    
    	public UnitOfWork()
    	{
    		var builder = new ContainerBuilder();
    		if (CurrentRepositoriesModule != null)
    			builder.RegisterModule(CurrentRepositoriesModule);
    		_container = builder.Build();
    	}
    
    	public T GetRepository<T>() where T : class
    	{
    		var targetType = typeof(T);
    		if (!_repositories.ContainsKey(targetType))
    		{
    			_repositories.Add(targetType, _container.Resolve<T>());
    		}
    		return (T)_repositories[targetType];
    	}
    
    	public void SaveChanges()
    	{
    		throw new NotImplementedException();
    	}
    
    }
