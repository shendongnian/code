     private static void ApplySerializerSettings(JsonSerializer serializer, JsonSerializerSettings settings)
        {
            if (!CollectionUtils.IsNullOrEmpty(settings.Converters))
            {
                // insert settings converters at the beginning so they take precedence
                // if user wants to remove one of the default converters they will have to do it manually
                for (int i = 0; i < settings.Converters.Count; i++)
                {
                    serializer.Converters.Insert(i, settings.Converters[i]);
                }
            }
