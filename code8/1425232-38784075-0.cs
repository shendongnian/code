    public static IEnumerable<object> SomeMethod(object reallyADict)
    {
        PropertyInfo propKeys = reallyADict?.GetType().GetProperty("Keys");
        if (propKeys == null) yield break;
        IEnumerable<string> keys = (IEnumerable<string>)propKeys.GetValue(reallyADict);
        PropertyInfo propIndex = reallyADict.GetType().GetProperty("Item");
        if (propIndex == null) yield break;
        foreach (string key in keys)
            yield return propIndex.GetMethod.Invoke(reallyADict, new object[] {key});
    }
