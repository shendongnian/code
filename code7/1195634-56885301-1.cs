    public class GetOnlyContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                if (property != null) // Change here (1)
                {
                    var attributes = property.AttributeProvider.GetAttributes(typeof(GetOnlyJsonPropertyAttribute), true);
                    if (attributes != null && attributes.Count > 0)
                        property.ShouldDeserialize = (a) => false;  // Change here (2)
                }
                return property;
            }
        }
