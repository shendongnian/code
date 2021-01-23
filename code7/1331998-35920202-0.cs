    public static class JsonHelpers
    {
        public static T DeserializeObject<T>(this string jsonString)
        {
            try
            {
                var concreteObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
                return concreteObject;
            }
            catch
            {
                return default(T);
            }
        }
        public static string SerializeObject<T>(this T concreteObject)
        {
            try
            {
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(concreteObject);
                return jsonString;
            }
            catch
            {
                return null;
            }
        }
    }
