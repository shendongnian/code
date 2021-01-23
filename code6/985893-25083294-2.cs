    public PocoData ForObject(object o, string primaryKeyName)
    {
        var t = o.GetType(); // This is where the exception comes from
        ...
    }
