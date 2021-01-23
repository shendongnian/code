    public static class MapperExtensions
    {
        public static T ResolveJson<T>(this JObject jobj, string target)
        {
            return JsonConvert.DeserializeObject<T>(jobj.SelectToken(target).ToString());
        }
    }
