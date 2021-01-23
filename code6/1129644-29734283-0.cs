    public class JsonDataConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Data<T>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var data = ((Data<T>)existingValue) ?? new Data<T>();
            var obj = JObject.Load(reader);
            data.Name = (string)obj["name"];
            data.DataResponse = obj[data.Name].ToObject<T>(serializer);
            return data;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var data = (Data<T>)value;
            var dict = new Dictionary<string, object> 
            {
                { "name", data.Name },
                { data.Name, data.DataResponse },
            };
            serializer.Serialize(writer, dict);
        }
    }
    public sealed class Root<T>  
    {
        public Data<T> data { get; set; }
    }
    public sealed class Data<T> 
    {
        public string Name { get; set; }
        public T DataResponse { get; set; }
    }
