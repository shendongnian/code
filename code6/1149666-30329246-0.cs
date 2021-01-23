    public class DistanceConverter : JsonConverter
    {
        private readonly IDictionary<string, DistanceType> _distanceTypeMap;
        public DistanceConverter()
        {
            _distanceTypeMap = new Dictionary<string, DistanceType>
            {
                {"Meters", DistanceType.Meter},
                {"Yards", DistanceType.Yard}
            };
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Distance distance = value as Distance;
            if (distance == null)
            {
                writer.WriteNull();
                return;
            }
            writer.WriteStartObject();
            foreach (KeyValuePair<string, DistanceType> pair in _distanceTypeMap)
            {
                writer.WritePropertyName(pair.Key);
                writer.WriteValue(distance.GetValue(pair.Value));
            }
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Distance result = null;
            while (reader.Read())
            {
                var key = reader.Value;
                string value = reader.ReadAsString();
                if (result == null && key != null)
                {
                    DistanceType distanceType;
                    if (_distanceTypeMap.TryGetValue(key.ToString(), out distanceType))
                    {
                        double parsedValue = JToken.Parse(value).Value<double>();
                        result = new Distance(distanceType, parsedValue);
                    }
                }
            }
            return result;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Distance) == objectType;
        }
    }
