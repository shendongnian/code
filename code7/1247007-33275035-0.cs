    internal XmlObjectSerializerContext(DataContractSerializer serializer, DataContract rootTypeDataContract, DataContractResolver dataContractResolver)  
        : this(serializer, serializer.MaxItemsInObjectGraph, new StreamingContext(StreamingContextStates.All), serializer.IgnoreExtensionDataObject, dataContractResolver)
    {
        // ...
    }
