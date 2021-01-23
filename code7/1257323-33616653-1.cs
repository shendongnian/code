    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;
    ...
    public static string GetFields(Type modelType)
    {
        return string.Join(",",
            modelType.GetProperties()
                     .Select(p => p.GetCustomAttribute<JsonPropertyAttribute>())
                     .Select(jp => jp.PropertyName));
    }
