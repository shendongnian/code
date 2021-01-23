    JsonSerializer innerSerializer = new JsonSerializer();
    foreach (var converter in serializer.Converters.Where(c => !(c is CustomInfoConverter)))
    {
        innerSerializer.Converters.Add(converter);
    }
    innerSerializer.Serialize(writer, customType);
