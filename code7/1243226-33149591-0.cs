    public class SensitiveDataResolver : DefaultContractResolver
    {
    	protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    	{
    		if (this.IsSensitiveProperty(member))
    		{
    			((PropertyInfo)member).SetValue(member, "SensitiveData", null);
    		}
    		
    		var property = base.CreateProperty(member, memberSerialization);
    		return property;
    	}
    	
    	private bool IsSensitiveProperty(MemberInfo member)
    	{
    		if (member is PropertyInfo)
    		{
    			var prop = (PropertyInfo) member;
    			var isSensitiveData = Attribute.IsDefined(prop, typeof (SensitiveDataAttribute));
    			return isSensitiveData;
    		}
    		return false;
    	}
    }
