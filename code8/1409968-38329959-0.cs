    private object GetFieldOrProperty(object obj, string name)
    {
        Type objType = obj.GetType();
        if (objType.GetField(name) != null)
            return objType.GetField(name).GetValue(obj);
        if (objType.GetProperty(name) != null)
            return objType.GetProperty(name).GetValue(obj, null);
        return null;
    }
