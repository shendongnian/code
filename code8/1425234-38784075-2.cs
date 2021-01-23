    public IEnumerable<object> SomeMethod(object reallyADict)
    {
        Type genericInterface = reallyADict?.GetType().GetInterface("IDictionary`2");
        PropertyInfo propKeys = genericInterface?.GetProperty("Keys");
        if (propKeys?.GetMethod == null) yield break;
        IEnumerable<string> keys = (IEnumerable<string>)propKeys.GetValue(reallyADict);
        PropertyInfo propIndex = genericInterface.GetProperty("Item");
        if (propIndex?.GetMethod == null) yield break;
        foreach (string key in keys)
            yield return propIndex.GetMethod.Invoke(reallyADict, new object[] { key });
    }
