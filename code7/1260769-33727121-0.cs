    public sealed class ConditionalCamelCaseContractResolver : IContractResolver
    {
        readonly static IContractResolver defaultContractResolver;
        readonly static IContractResolver camelCaseContractResolver;
        readonly static ConcurrentDictionary<Type, bool> camelCaseTable;
        static Func<Type, bool> isCamelCase;
        // Use a static constructor for lazy initialization.
        static ConditionalCamelCaseContractResolver()
        {
            defaultContractResolver = new JsonSerializer().ContractResolver; // This seems to be the only way to access the global singleton default contract resolver.
            camelCaseContractResolver = new CamelCasePropertyNamesContractResolver();
            camelCaseTable = new ConcurrentDictionary<Type, bool>();
            isCamelCase = (t) => GetIsCamelCase(t);
        }
        static bool GetIsCamelCase(Type objectType)
        {
            if (objectType.Assembly.GetCustomAttributes<JsonCamelCaseAttribute>().Any())
                return true;
            if (objectType.GetCustomAttributes<JsonCamelCaseAttribute>(true).Any())
                return true;
            foreach (var type in objectType.GetInterfaces())
                if (type.GetCustomAttributes<JsonCamelCaseAttribute>(true).Any())
                    return true;
            return false;
        }
        static bool IsCamelCase(Type objectType)
        {
            var code = Type.GetTypeCode(objectType);
            if (code != TypeCode.Object && code != TypeCode.Empty)
                return false;
            return camelCaseTable.GetOrAdd(objectType, isCamelCase);
        }
        #region IContractResolver Members
        public JsonContract ResolveContract(Type type)
        {
            return IsCamelCase(type) ? camelCaseContractResolver.ResolveContract(type) : defaultContractResolver.ResolveContract(type);
        }
        #endregion
    }
    [System.AttributeUsage(System.AttributeTargets.Assembly | System.AttributeTargets.Class | System.AttributeTargets.Interface)]
    public class JsonCamelCaseAttribute : System.Attribute
    {
        public JsonCamelCaseAttribute()
        {
        }
    }
