    public class UpperCaseContractResolver : DefaultContractResolver
    {
        public static readonly UpperCaseContractResolver Instance = new UpperCaseContractResolver();
    
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            property.PropertyName = property.PropertyName.ToUpper();
            return property;
        }
    }
