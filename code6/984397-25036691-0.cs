    public class DeclaredMembersResolver<T> : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> filtered = new List<JsonProperty>();
    
            foreach (JsonProperty p in base.CreateProperties(type, memberSerialization))
                if(p.DeclaringType == typeof(T)) 
                    filtered.Add(p);
    
            return filtered;
        }
    }
    
    // Example of use:
    var ser = JsonSerializer.CreateDefault(new JsonSerializerSettings() {
      ContractResolver = new DeclaredMembersResolver<BaseClass>()
    });
    ser.Serialize(writer, obj); // Only the base properties of obj will be written
