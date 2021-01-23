    public class FieldsSelectContractResolver : CamelCasePropertyNamesContractResolver
    {
    	protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    	{
    	    var property = base.CreateProperty(member, memberSerialization);
    
    	    property.GetIsSpecified = (t) =>
    	    {
    		var fields = HttpContext.Current.Request["fields"];
    
    		if (fields != null)
    		{
    		    return fields.IndexOf(member.Name, StringComparison.OrdinalIgnoreCase) > -1;
    		}
    
    		return true;
    	    };
    
    	    return property;
    	}
    }
