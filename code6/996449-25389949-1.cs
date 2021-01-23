    public class ReferenceLinkingValueProvider : IValueProvider
    {
    	#region Fields
    	private PropertyInfo m_property;
    	#endregion
    
    	#region Constructors
    	public ReferenceLinkingValueProvider(PropertyInfo property)
    	{
    	    m_property = property;
    	}
    	#endregion
    
    	#region Methods
    	public object GetValue(object target)
    	{
    	    if (target == null)
    	    {
    		    return null;
    	    }
    
    	    var value = m_property.GetValue(target);
    	    var entity = value as DomainEntityBase;
    
    	    if (entity == null)
    	    {
    		return value;
    	    }
    
    	    // If your resources are in plural, you will need some helper method 
    	    // to put in right plural (remember the resources with 'ing' ends).
    	    var resourceName = entity.GetType().Name;
    
            // Here is where the real work happens. You change the entire entity
            // serialization to just the href property.
    	    return new
    	    {
    		href = "http://app.com/api/{0}/{1}".With(resourceName, entity.Id)
    	    };
    	}
    
    	public void SetValue(object target, object value)
    	{
    	    m_property.SetValue(target, value);
    	}
    	#endregion
    }
