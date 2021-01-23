    public abstract class Builder<TEntity, TBuilder>
            where TEntity : Entity, IKey, new()
            where TBuilder : Builder<TEntity, TBuilder>, new()
    {
    	protected int _id { get; set; }
    	protected ObjectState _objectState { get; set; }
    
    	public Builder()
    	{
    		_objectState = ObjectState.Added;
    	}
    
    	public virtual Builder<TEntity, TBuilder> WithId(int id)
    	{
    		this._id = id;
    		return this;
    	}
    
    	public virtual Builder<TEntity, TBuilder> WithObjectState(ObjectState objectState)
    	{
    		this._objectState = objectState;
    		return this;
    	}
    
    	public static implicit operator TEntity(Builder<TEntity, TBuilder> builder)
    	{
    		return new TEntity
    		{
    			Id = builder._id,
    			ObjectState = builder._objectState
    		};
    	}
    }
