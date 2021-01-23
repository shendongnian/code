    class FluffDataConverter : JsonConverter
    {
        readonly int PrefixLength = "Fluff_".Length;
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Data));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            List<Thing> things = jo.Properties()
                                   .OrderBy(p => int.Parse(p.Name.Substring(PrefixLength)))
                                   .Select(p => p.Value.ToObject<Thing>())
                                   .ToList();
            return new Data { Things = things };
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
