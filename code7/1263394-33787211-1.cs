    public class InMemoryDatabase
    {
    	static readonly Dictionary<Type, Func<InMemoryDatabase, object>> collectionMap;
    	static InMemoryDatabase()
    	{
    		collectionMap =
    			(from p in typeof(InMemoryDatabase).GetProperties()
    			 where p.CanRead &&
    				p.PropertyType.IsGenericType && 
    				p.PropertyType.GetGenericTypeDefinition() == typeof(HashSet<>)
    			 select new
                 {
                     Type = p.PropertyType.GetGenericArguments()[0],
                     Selector = (Func<InMemoryDatabase, object>)Delegate.CreateDelegate(
                         typeof(Func<InMemoryDatabase, object>), p.GetMethod)
                 }).ToDictionary(e => e.Type, e => e.Selector);
    	}
    	public HashSet<TEntity> GetCollection<TEntity>()
    	{
    		return (HashSet<TEntity>)collectionMap[typeof(TEntity)](this);
    	}
        // Collections
    	public HashSet<Car> Cars { get; set; }
    	public HashSet<Truck> Trucks { get; set; }
    	public HashSet<Bike> Bikes { get; set; }
        // ...
    }
