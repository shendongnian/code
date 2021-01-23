    public sealed class Root
    {
        public Data data { get; set; }
    }
    [JsonConverter(typeof(DataResponseConverter))]
    public sealed class Data
    {
        public string Name { get; set; }
        public DataResponse DataResponse { get; set; }
    }
    class DataResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Data);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var data = ((Data)existingValue) ?? new Data();
            var obj = JObject.Load(reader);
            data.Name = (string)obj["name"];
            data.DataResponse = obj[data.Name].ToObject<DataResponse>(serializer);
            return data;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var data = (Data)value;
            var dict = new Dictionary<string, object> 
            {
                { "name", data.Name },
                { data.Name, data.DataResponse },
            };
            serializer.Serialize(writer, dict);
        }
    }
