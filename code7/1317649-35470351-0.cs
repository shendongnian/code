    ((IDCollection)FindBase(SortMethod).GetNestedType("CustomSort", bindingFlags).GetField("Methods").GetValue(null)).Add(ref name);
    static Type FindBase(Type t)
    {
        if (t.BaseType != typeof (object))
            return FindBase(t.BaseType);
        return t;
    }
