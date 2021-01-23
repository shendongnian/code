    static Type GetObjectTypeOrNull(object o)
    {
        return o == null ? null : o.GetType();
    }
    
    static IEnumerable<List<object>> PartitionByTypes(List<object> values)
    {
        if (values == null) throw new ArgumentNullException("values");
        if (values.Count == 0) yield break;
    
        Type currentType = GetObjectTypeOrNull(values);
        List<object> buffer = new List<object>();
        foreach (object value in values)
        {
            Type valueType = GetObjectTypeOrNull(value);
            if (valueType != currentType)
            {
                currentType = valueType;
                yield return buffer;
                buffer = new List<object>();
            }
    
            currentType = valueType;
            buffer.Add(value);
        }
    
        if (buffer.Count > 0)
        {
            yield return buffer;
        }
    }
