    public class JsonExtensions
    {
        public static string SerializeObjectNoCache<T>(T obj, JsonSerializerSettings settings = null)
        {
            settings = settings ?? new JsonSerializerSettings();
            if (settings.ContractResolver == null)
                // To reduce memory footprint, do not cache contract information in the global contract resolver.
                settings.ContractResolver = new DefaultContractResolver();
            return JsonConvert.SerializeObject(obj, settings);
        }
    }
