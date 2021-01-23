    IList dest = Array.CreateInstance(ek, sourceList.Count);
    for (int i = 0; i < sourceList.Count; i++)
    {
        dest[i] = Activator.CreateInstance(ek);
    }
    K result = (K) dest;
    // Note that this is calling MapItem<T, K>, not MapItem<T, object[]>
    MapItem(source, result);
    return result;
