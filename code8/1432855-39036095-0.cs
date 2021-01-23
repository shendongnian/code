    container.RegisterInstance<Func<Type, IDocumentCollectionName>>(type =>
    {
        if (type == typeof(ClassA))
            return
                (IDocumentCollectionName)
                    container.Resolve(typeof(CollectionNameFromClassName<>).MakeGenericType(type));
        else
            return (IDocumentCollectionName)
                container.Resolve(typeof(CollectionNameFromString));
    
    });
