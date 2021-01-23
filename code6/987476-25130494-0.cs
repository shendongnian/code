    Type type = p.GetType();
    Type keyType = type.GetGenericArguments()[0];
    Type valueType = type.GetGenericArguments()[1];
    var dictionary =
        (IDictionary) Activator
            .CreateInstance(typeof(SerializableDictionary<,>)
            .MakeGenericType(new Type[] { keyType, valueType }));
            
    foreach(var item in stronglyTypedDictionary)
    {
        dictionary.Add(item.Key, item.Value);
    }
