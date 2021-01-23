    public abstract class BarBaseJsonConverter : JsonConverter
    {
        public JsonSerializer GetSerializer()
        {
            var serializerSettings = JsonHelper.DefaultSerializerSettings;
            serializerSettings.TypeNameHandling = TypeNameHandling.Objects;
    
            var converters = serializerSettings.Converters != null
                ? serializerSettings.Converters.ToList()
                : new List<JsonConverter>();
            var thisConverter = converters.FirstOrDefault(x => x.GetType() == GetType());
            if (thisConverter != null)
            {
                converters.Remove(thisConverter);
            }
            serializerSettings.Converters = converters;
    
            return JsonSerializer.Create(serializerSettings);
        }
    }
