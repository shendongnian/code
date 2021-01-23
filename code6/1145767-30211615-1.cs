    public static class JsonHelper
    {
        public static bool IsInstanceOf<T>(this JsonObject jsonObject)
        {
            if (jsonObject == null || !jsonObject.ContainsKey("ClassName"))
            {
                return false;
            }
    
            return jsonObject["ClassName"] == typeof(T).FullName;
        }
    }
