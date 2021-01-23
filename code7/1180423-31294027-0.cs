    class CustomResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty prop = base.CreateProperty(member, memberSerialization);
    
                if (member.MemberType == MemberTypes.Field && (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string)))
                {
                    prop.ShouldSerialize = obj => true;
                }
                else if (prop.PropertyType.IsSubclassOf(typeof(DataItem)))
                {
                    prop.ShouldSerialize = obj => true;
                    prop.Converter = new DataItemConverter();
                }
                else
                {
                    prop.ShouldSerialize = obj => false;
                }
    
                return prop;
            }
        }
