    public class MyExpandoReplacement : DynamicObject
    {
    	private Dictionary<string, object> _properties = new Dictionary<string, object>();
    	public override bool TryGetMember(GetMemberBinder binder, out object result)
    	{
    		if (!_properties.ContainsKey(binder.Name))
    		{
    			result = GetDefault(binder.ReturnType);
    			return true;
    		}
    
    		return _properties.TryGetValue(binder.Name, out result);
    	}
    
    	public override bool TrySetMember(SetMemberBinder binder, object value)
    	{
    		this._properties[binder.Name] = value;
    		return true;
    	}
    
    	private static object GetDefault(Type type)
    	{
    		if (type.IsValueType)
    		{
    			return Activator.CreateInstance(type);
    		}
    		return null;
    	}
    }
