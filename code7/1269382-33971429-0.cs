    public class CustomDateConverter : Newtonsoft.Json.Converters.DateTimeConverterBase
    {
        private static readonly string DateTimeFormat = "dd-MM-yyyy";
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DateTime res; // default value of a date is 01/01/0001
    
            // if parsing is successful that value will be changed, otherwise you get the default value and not and exception
            DateTime.TryParseExact(reader.Value.ToString(), DateTimeFormat, null, DateTimeStyles.None, out res); 
            
            return res;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString(DateTimeFormat));
        }
    }
