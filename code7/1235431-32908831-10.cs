    public class CamelCaseIgnoringPropertyJsonResolver<T> : CamelCasePropertyNamesContractResolver
    {        
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            // list the properties to ignore
            var propertiesToIgnore =  type.GetProperties()
                    .Where(x => x.GetCustomAttributes().OfType<T>().Any());
            // Build the properties list
            var properties = base.CreateProperties(type, memberSerialization);
            // only serialize properties that are not ignored
            properties = properties
                .Where(p => propertiesToIgnore.All(info => info.Name != p.UnderlyingName))
                .ToList();
            return properties;
        }
    }
    
