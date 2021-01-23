    public class NoJsonPropertyNameContractResolver : DefaultContractResolver
    {
         
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            property.PropertyName = property.UnderlyingName;
            return property;
        }
    }
