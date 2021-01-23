    public class TypeList<T>
    {
    	private readonly List<Type> types = new List<Type>();
    	public void Add<D>() where D : T, new()
    	{
    		this.types.Add(typeof(D));
    	}
    
    	public T NewAt(int index)
    	{
    		return (T)Activator.CreateInstance(this.types[index]);
    	}
    }
