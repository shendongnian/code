    var foo = (Foo)value;
    writer.WriteStartObject();
    writer.WritePropertyName("OtherProperties");
    writer.WriteValue(foo.OtherProperties);
    var index = 0;
    
    foreach (var item in foo.FooCollection)
    {
        var properties = typeof(T).GetProperties();
        foreach (var propertyInfo in properties)
        {
            var stringName = $"fooCollection[{index}].{propertyInfo.Name}";
            writer.WritePropertyName(stringName);
            serializer.Serialize(writer, propertyInfo.GetValue(item, null));
         }
    
         index++;
    }
    writer.WriteEndObject();
