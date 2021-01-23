    class JsonHelper
    {
        private const string JsonFormat = "{{{0}}}";
        public static T Deserialize<T>(string json,string name)
        {
            var jObj = JObject.Parse(string.Format(JsonFormat, json));
            var obj = jObj[name].ToObject<T>();
            return obj;
        }
        public static T Deserialize<T>(string json)
        {
            return Deserialize<T>(typeof (T).Name, json);
        }
    }
