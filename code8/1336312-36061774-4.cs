    var swaggerDocument = JsonConvert.DeserializeObject<SwaggerDocument>(json, new JsonSerializerSettings
    {
    	ContractResolver = new MyContractResolver()
    });
    
    public class MyContractResolver : DefaultContractResolver
    {
    	protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    	{
    		var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
    			.Select(p => base.CreateProperty(p, memberSerialization))
    			.Union(type.GetFields(BindingFlags.Public | BindingFlags.Instance)
    				.Select(f => base.CreateProperty(f, memberSerialization)))
    			.ToList();
    		props.ForEach(p => { p.Writable = true; p.Readable = true; });
    		return props;
    	}
    }
