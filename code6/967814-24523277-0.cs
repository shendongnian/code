    public IEnumerable<string> GetClassAttribute(string className)
    {
        Type t = Type.GetType(className);
        return t.GetFields().Select(f=>f.Name);
    }
