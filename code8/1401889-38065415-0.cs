    public IEnumerable<V> EnumerateValues()
    {
        foreach (var kv in privateList) yield return kv.Value;
    }
    public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
    {
        return EnumerateValues().GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
