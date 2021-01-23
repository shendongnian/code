    public class DictionaryConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dictionary = (Dictionary<Gender, int>) value;
            writer.WriteStartObject();
            foreach (KeyValuePair<Gender, int> pair in dictionary)
            {
                writer.WritePropertyName(((int)pair.Key).ToString());
                writer.WriteValue(pair.Value);
            }
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var maleValue = int.Parse(jObject[((int) Gender.Male).ToString()].ToString());
            var femaleValue = int.Parse(jObject[((int)Gender.Female).ToString()].ToString());
            (existingValue as Dictionary<Gender, int>).Add(Gender.Male, maleValue);
            (existingValue as Dictionary<Gender, int>).Add(Gender.Female, femaleValue);
            return existingValue;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof (IDictionary<Gender, int>) == objectType;
        }
    }
