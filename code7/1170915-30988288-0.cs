    [JsonConverter(typeof(ClickConverter))]
    public class Click
    {
        public DateTime Date { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public int Count { get; set; }
    }
    public class ClickConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Click).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token == null || token.Type == JTokenType.Null)
                return null;
            var click = (existingValue as Click ?? new Click());
            var key = token["key"] as JArray;
            if (key != null && key.Count > 0)
                click.Date = DateTime.Parse((string)key[0], CultureInfo.InvariantCulture);
            if (key != null && key.Count > 1)
                click.Code = (string)key[1];
            if (key != null && key.Count > 2)
                click.Url = (string)key[2];
            var count = token["value"];
            if (count != null)
                click.Count = (int)count;
            return click;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Fill in with the opposite of the code above, if needed
            var click = value as Click;
            if (click == null)
                writer.WriteNull();
            else
                serializer.Serialize(writer,
                    new
                    {
                        // Update the date string format as approptiate
                        // https://msdn.microsoft.com/en-us/library/8kb3ddd4%28v=vs.110%29.aspx
                        key = new string[] { click.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), click.Code.ToString(CultureInfo.InvariantCulture), click.Url },
                        value = click.Count
                    });
        }
    }
    public class RootObject
    {
        public List<Click> rows { get; set; }
    }
