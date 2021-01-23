    public abstract class EntityId<TEntityId>
    	where TEntityId : EntityId<TEntityId>
    {
    	private readonly System.Guid value;
    
    	protected EntityId(string value)
    	{
    		this.value = System.Guid.Parse(value);
    	}
    
    	protected EntityId()
    	{
    		this.value = System.Guid.NewGuid();
    	}
    
    	public static TEntityId Parse(string value)
    	{
    		return (TEntityId)Activator.CreateInstance(typeof(TEntityId), new object[] { value });
    	}
    }
