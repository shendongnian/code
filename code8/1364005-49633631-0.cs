    void Main()
    {
    	Person person = new Person();
    	person.MyAddress = new Address();
    	var ret = person.ShouldSerializeMyAddress();
    
    	var json = JsonConvert.SerializeObject(person, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
    	{
    		NullValueHandling = NullValueHandling.Ignore
    	});
    	json.Dump();	
    }
    
    public static class JsonExtensions
    {
    	public static bool ShouldSerialize<T>(T shouldSerializeParam)
    	{			 
    		var shouldSerializeMethods = typeof(T).GetMethods().Where(p => p.Name.StartsWith("ShouldSerialize"));
    		foreach (var method in shouldSerializeMethods)
    		{
    			if (Convert.ToBoolean(method.Invoke(shouldSerializeParam, new object[] { }))) return true;
    		}
    		return false;
    	}
    }
    
    public class Person
    {	
    	public Address MyAddress { get; set; }	
    	public bool ShouldSerializeMyAddress()
    	{
    		return JsonExtensions.ShouldSerialize<Address>(MyAddress);			
    	}
    }
    
    public class Address
    {
    	public string Street { get; set; }
    	public bool ShouldSerializeStreet()
    	{
    		return false;  // or whatever your property serialization criteria should be
    	}
    	public string City { get; set; }
    	public bool ShouldSerializeCity()
    	{
    		return false;
    	}
    	public string State { get; set; }
    	public bool ShouldSerializeState()
    	{
    		return false;
    	}
    	public string Zip { get; set; }
    	public bool ShouldSerializeZip()
    	{
    		return false;
    	}
    }
