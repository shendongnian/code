        public class IntegerEnumConverter : StringEnumConverter
        {
            public override bool CanRead { get { return false; } }
            public override bool CanWrite { get { return false; } }
        }
    And then use it like:
        var json = JsonConvert.SerializeObject(value, Formatting.None, new JsonSerializerSettings { Converters = new JsonConverter[] { new IntegerEnumConverter() } });
    The locally specified converter will be picked up in preference to the default converter.
