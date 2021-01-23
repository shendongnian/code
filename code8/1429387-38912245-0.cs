    // Load type name from json - you'll need to implement LoadTypeFromJson() method to load type name string from json
    string typeName = LoadTypeFromJson()
    // Get .Net Type by type name
    Type entityType = Type.GetTypeByName(typeName);
    // Get Serializer type
    Type serializerType = typeof(Serializer);
    // Get MethodInfo for Deserialize method
    MethodInfo deserializeMethodInfo = serializerType.GetMethod("Deserialize");
    // Construct Deserialize<IEntity> method for specific IEntity
    MethodInfo constructedDeserializeMethod = deserializeMethodInfo.MakeGenericMethod(entityType);
    
    // Call constructed method
    constructedDeserializeMethod.Invoke(null, new object[] { jsonString })
