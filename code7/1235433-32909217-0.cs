    public class MyContractResolver<T> : Newtonsoft.Json.Serialization.DefaultContractResolver 
                                            where T : Attribute
    {
        Type _AttributeToIgnore = null;
        public MyContractResolver()
        {
            _AttributeToIgnore = typeof(T);
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var list =  type.GetProperties()
                        .Where(x => !x.GetCustomAttributes().Any(a => a.GetType() == _AttributeToIgnore))
                        .Select(p => new JsonProperty()
                        {
                            PropertyName = p.Name,
                            PropertyType = p.PropertyType,
                            Readable = true,
                            Writable = true,
                            ValueProvider = base.CreateMemberValueProvider(p)
                        }).ToList();
            return list;
        }
    }
