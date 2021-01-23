    public class GenericResolver<TEntity> : IReferenceResolver
    	where TEntity : ICloneable, new()
    {
        private readonly IDictionary<string, TEntity> _objects = new Dictionary<string, TEntity>();
    	private readonly Func<TEntity, string> _keyReader;
    
    	public GenericResolver(Func<TEntity, string> keyReader)
    	{
    		_keyReader = keyReader;
    	}
    	
        public object ResolveReference(object context, string reference)
        {
    		TEntity o;
    		if (_objects.TryGetValue(reference, out o))
            {
    			return o.Clone();
    		}
    
    		return null;
        }
    
        public string GetReference(object context, object value)
    	{
    		var o = (TEntity)value;
    		var key = _keyReader(o);
    		_objects[key] = o;
    
    		return key;
    	}
    
    	public bool IsReferenced(object context, object value)
    	{
    		var o = (TEntity)value;
    		return _objects.ContainsKey(_keyReader(o));
    	}
    
    	public void AddReference(object context, string reference, object value)
        {
    		if(value is TEntity)
            	_objects[reference] = (TEntity)value;
    	}
    }
