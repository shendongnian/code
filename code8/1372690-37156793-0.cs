    void Main()
    {
    	var repository = GetRepository<MyEntity1>();
    	MyEntity1 instance = repository.Get(1);
    }
    
    class MyEntity1
    {
    }
    
    ConcurrentDictionary<Type, object> repositories = new ConcurrentDictionary<System.Type, object>();
    
    interface IRepository<T>
    {
    	T Get(int id);
    }
    
    class Repository<T> : IRepository<T> where T:new()
    {
    	public T Get(int id)
    	{
    		return new T();
    	}
    }
    
    IRepository<T> GetRepository<T>() where T:new()
    {
    	return (IRepository<T>)repositories.GetOrAdd(typeof(T), t => new Repository<T>());
    }
