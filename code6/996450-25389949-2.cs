    public class ReferenceLinkContractResolver : CamelCasePropertyNamesContractResolver
    {
    	#region Methods
    	protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    	{
    	    var properties = base.CreateProperties(type, memberSerialization);
    	    var childProperties = properties.Where(p => typeof(DomainEntityBase).IsAssignableFrom(p.PropertyType));
    
    	    foreach (var c in childProperties)
    	    {
    		c.ValueProvider = new ReferenceLinkingValueProvider(ReflectionHelper.GetProperty(type, c.PropertyName));
    	    }
    
    	    return properties;
    	}
    	#endregion
    }
