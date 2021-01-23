    var deserializedTypes = new List<Type> {
        typeof(DeclarationRealisation) // ...etc...
    };
    
    foreach (var extensionType in extensionTypes) { // Includes Struct and more
        deserializedTypes.Add(extensionType);
    }
    
    var generatedSerializers = XmlSerializer.FromTypes(deserializedTypes.ToArray());
    for (int i = 0; i < generatedSerializers.Length; i++) {
        var xmlType = deserializedTypes[i];
        var serializer = generatedSerializers[i];
        serializers[xmlType] = serializer;
    }
