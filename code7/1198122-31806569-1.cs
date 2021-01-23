    private static JsonSerializerSettings CreateSettings()
        {
            var settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            return settings;
        }
    private static Newtonsoft.Json.JsonSerializer CreateSerializer()
        {
            var settings = CreateSettings();
            return Newtonsoft.Json.JsonSerializer.Create(settings);
        }
    public T Deserialize<T>(object target)
        {
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            var result = default(T);
            var json = target as string;
            if (json != null)
            {
                var serializer = CreateSerializer();
                using (var stringReader = new StringReader(json))
                {
                    using (JsonReader jsonReader = new JsonTextReader(stringReader))
                    {
                        result = serializer.Deserialize<T>(jsonReader);
                    }
                }
            }
            return result;
        }
