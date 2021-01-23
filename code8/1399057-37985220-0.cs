    public class MyClass : DynamicObject
    {
    	public string Prop { get; set; }
    
    	Dictionary<string, object> dynamicMembers = new Dictionary<string, object>();
    
    	public override bool TrySetMember(SetMemberBinder binder, object value)
    	{
    		dynamicMembers[binder.Name] = value;
    		return true;
    	}
    
    	public override bool TryGetMember(GetMemberBinder binder, out object result)
    	{
    		return dynamicMembers.TryGetValue(binder.Name, out result);
    	}
    }
