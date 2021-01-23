    public static class JsonNestedDictionaryExtensions
    {
        public static Object GetValue(this Dictionary<String,Object> dict, params string[] keys)
        {
            Object dictObject = dict;
            String lastKey = "";
            foreach (string key in keys)
            {
                 if (!dictObject is Dictionary<String,Object>)
                     throw new ArgumentException(key+ " cannot be accessed because "+lastKey+" is not a dictionary");
                 dict = (Dictionary<String,Object>) dictObject;
                 dictObject = dict["key"];
                 lastKey = key;
            }
            return dictObject;
        }
    }
