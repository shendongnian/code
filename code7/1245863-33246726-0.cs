    class CustomResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            foreach (JsonProperty prop in props)
            {
                if (!prop.PropertyType.IsPrimitive && prop.PropertyType != typeof(string))
                {
                    PropertyInfo pi = type.GetProperty(prop.UnderlyingName);
                    if (pi != null && pi.CanRead)
                    {
                        var childPropertiesToSerialize = pi.GetCustomAttributes<SerializeOnly>()
                                                           .Select(att => att.PropertyName);
                        if (childPropertiesToSerialize.Any())
                        {
                            prop.Converter = new CustomConverter(childPropertiesToSerialize);
                        }
                    }
                }
            }
            return props;
        }
    }
