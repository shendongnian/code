    public class DynamicContractResolver : DefaultContractResolver
    {
    
    	private Type _typeToIgnore;
    	public DynamicContractResolver(Type typeToIgnore)
    	{
    		_typeToIgnore = typeToIgnore;
    	}
    
    	protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    	{
    		IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
    
    		properties = properties.Where(p => p.PropertyType != _typeToIgnore).ToList();
    
    		return properties;
    	}
    }
