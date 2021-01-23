    public class CustomContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);
    #if DEBUG
            if(prop != null)
            {
                // If in debug mode -> return PropertyName value to the initial member name. 
                prop.PropertyName = member.Name;
            }
    #endif
            return prop;
        }
    }
