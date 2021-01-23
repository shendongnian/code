    internal class CustomJsonFormatter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(Thing));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var data = value as Thing;
            foreach (var prop in data.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                writer.WriteStartObject();
                writer.WritePropertyName(prop.Name);
                writer.WriteStartObject();
                var local = prop.GetValue(data, null) as Dictionary<string, object>;
                foreach (var key in local.Keys)
                {
                    writer.WritePropertyName(key);
                    if (local[key].GetType() == typeof(List<int>))
                    {
                        string s = "[";
                        var arr = ((List<int>)local[key]);
                        for (var i = 0; i < arr.Count; i++)
                        {
                            s += arr[i].ToString() + ",";
                        }
                        writer.WriteValue(s.Substring(0, s.Length - 1) + "]");
                    }
                    else { writer.WriteValue(local[key]); }
                }
            }
            writer.WriteEndObject();
            writer.WriteEndObject();            
    }
    var settings = new JsonSerializerSettings();
    settings.Converters.Add(new CustomJsonFormatter());
    string result = JsonConvert.SerializeObject(thing, settings);
