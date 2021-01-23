    public class MyClass : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            property.ShouldSerialize = obj =>
            {
                if (property.PropertyType.Name.Contains("ICollection"))
                {
                    return (property.ValueProvider.GetValue(obj) as dynamic).Count > 0;
                }
                return true;
            };
            return property;
        }
    }
     
 
