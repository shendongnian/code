    List<object> l = new List<object>();
    if(value.GetType().GetElementType().IsValueType)
    {
        foreach(object o in (IEnumerable)value)
        {
            l.Add(o);
        }
    }
    else
    {
        l.AddRange((IEnumerable<object>)value);
    }
