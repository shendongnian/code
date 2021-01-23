    public class ValueTypeConverter : JsonConverter
    {
        private static List<Type> SupportedTypes = new List<Type>
        {
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(DateTime)
        };
        
        private static Dictionary<Type, object> MinValues;
        
        static ValueTypeConverter()
        {
            MinValues = new Dictionary<Type, object>();
            
            foreach (Type type in SupportedTypes)
            {
                MinValues.Add(type, GetMinValue(type));
            }
        }
    
        public override object ReadJson(
            JsonReader reader, 
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            object value = reader.Value;
    
            value = value ?? MinValues[objectType];
            value = Convert.ChangeType(value, objectType);
            
            return value;
        }
        
        public override bool CanConvert(Type objectType)
        {
            return MinValues.ContainsKey(objectType);
        }
        
        public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
        {        
            object minValue = MinValues[value.GetType()];
            
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
