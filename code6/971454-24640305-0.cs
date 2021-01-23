    string json = @"{str1:""abc"",list:""[1,2,3]"", str2:""def""}";
    var temp = JsonConvert.DeserializeObject<Temp>(json);
    public class Temp
    {
        public string str1;
        [JsonConverter(typeof(StringConverter<List<int>>))]
        public List<int> list;
        public string str2;
    }
    public class StringConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return JsonConvert.DeserializeObject<T>((string)reader.Value);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
