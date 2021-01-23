    public class ValueTypeConverter : JsonConverter
    {
        private static HashSet<Type> SupportedTypes = new HashSet<Type>
        {
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(DateTime)
        };
    
        public override object ReadJson(
            JsonReader reader, 
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            object value = reader.Value;
    
            value = value ?? GetMinValue(objectType);
            value = Convert.ChangeType(value, objectType);
            
            return value;
        }
        
        public override bool CanConvert(Type objectType)
        {
            return SupportedTypes.Contains(objectType);
        }
        
        public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
        {        
            object minValue = GetMinValue(value.GetType());
            
            if (object.Equals(value, minValue))
            {
                value = null;
            }
            
            writer.WriteValue(value);
        }
        
        private static object GetMinValue(Type objectType)
        {
            FieldInfo minValueFieldInfo = objectType.GetField("MinValue");
            
            return minValueFieldInfo.GetValue(null);
        }
    }
