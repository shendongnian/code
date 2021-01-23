    class StopConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Stop));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray ja = JArray.Load(reader);
            Stop stop = new Stop();
            stop.Value = (decimal)ja[0];
            stop.Color = (string)ja[1];
            return stop;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JArray ja = new JArray();
            Stop stop = (Stop)value;
            ja.Add(stop.Value);
            ja.Add(stop.Color);
            ja.WriteTo(writer);
        }
    }
