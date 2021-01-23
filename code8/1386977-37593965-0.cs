    // no need to make this method generic
    private Source createInstanceFromJSON(Type type, string json)
    {
        // use reflection to get the method for type "type"
        var deserializeMethod =
            jsSerializer.GetType()
                        .GetMethod("Deserialize")
                        .MakeGenericMethod(new[] { type });
        
        // invoke the method on the jsSerializer object
        var item = (Source)deserializeMethod.Invoke(jsSerializer, new[] { json });
        return item;
    }
