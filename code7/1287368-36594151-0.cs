    public class CustomSerializationContractResolver : DefaultContractResolver
    {
        private Type _serializingType;
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            if (_serializingType == null)
            {
                _serializingType = member.DeclaringType;
            }
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (_serializingType == member.DeclaringType)
            {
                property.ShouldSerialize = (instance) => true;
            }
            else if(Attribute.IsDefined(member, typeof(WebApiRefAttribute)))
            {
                property.ShouldSerialize = (instance) => true;
            }
            else
            {
                property.ShouldSerialize = (instance) => false;
            }
            
            return property;
        }
    }
