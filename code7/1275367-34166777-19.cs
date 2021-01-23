    public class WritablePropertiesOnlyResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var result = base.CreateProperty(member, memberSerialization);
            if (typeof(LeaseInstrument).IsAssignableFrom(result.DeclaringType) && typeof(ICollection<LeaseOwner>).IsAssignableFrom(result.PropertyType))
            {
                var converter = new IgnoreCollectionTypeConverter { ItemConverterType = typeof(OwnerToLeaseOwnerConverter) };
                result.Converter = result.Converter ?? converter;
                result.MemberConverter = result.MemberConverter ?? converter;
            }
            return result;
        }
    }
