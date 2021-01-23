    public static class ObjectExtensions {
        public static String ConvertToJson<T>(this T obj) {       
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
