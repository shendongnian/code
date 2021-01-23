    protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
    {
        var c = base.CreateDictionaryContract(objectType);
        if (typeof(IDynamicMetaObjectProvider).IsAssignableFrom( c.UnderlyingType))
            c.ItemTypeNameHandling = TypeNameHandling.None;
        return c;
    }
