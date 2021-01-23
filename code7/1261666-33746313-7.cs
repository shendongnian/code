        public class ListReplacementContractResolver : DefaultContractResolver
        {
            // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
            // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
            // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
            // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
            static readonly ListReplacementContractResolver instance;
            // Using a static constructor enables fairly lazy initialization.  http://csharpindepth.com/Articles/General/Singleton.aspx
            static ListReplacementContractResolver() { instance = new ListReplacementContractResolver(); }
            public static ListReplacementContractResolver Instance { get { return instance; } }
            protected ListReplacementContractResolver() : base() { }
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var jsonProperty = base.CreateProperty(member, memberSerialization);
                if (jsonProperty.ObjectCreationHandling == null && jsonProperty.PropertyType.GetListType() != null)
                    jsonProperty.ObjectCreationHandling = ObjectCreationHandling.Replace;
                return jsonProperty;
            }
        }
        public static class TypeExtensions
        {
            public static Type GetListType(this Type type)
            {
                while (type != null)
                {
                    if (type.IsGenericType)
                    {
                        var genType = type.GetGenericTypeDefinition();
                        if (genType == typeof(List<>))
                            return type.GetGenericArguments()[0];
                    }
                    type = type.BaseType;
                }
                return null;
            }
        }
    Then use it with the following settings:
        var settings = new JsonSerializerSettings { ContractResolver = ListReplacementContractResolver.Instance };
