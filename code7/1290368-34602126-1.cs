    public class ExampleHotkeyTypeEnumConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                string enumText = reader.Value.ToString();
                if (!string.IsNullOrEmpty(enumText) && enumText.Equals("CaptureRegionWindow"))
                {
                    return ExampleHotkeyType.CaptureRegion;
                }
            }
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
    [JsonConverter(typeof(ExampleHotkeyTypeEnumConverter))]
    public enum ExampleHotkeyType
    {
        None,
        CaptureRegion,
        CaptureRegionWindow,
        CaptureRegionPolygon,
        CaptureRegionFreehand
    }
