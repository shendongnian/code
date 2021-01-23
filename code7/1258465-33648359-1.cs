    var getValue = GetPrivateProperty<bool>(class, "BoolProperty");
    public static T GetPrivateProperty<T>(object obj, string name)
    {
        BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        PropertyInfo field = null;
        var objType = obj.GetType();
        while (objType != null && field == null)
        {
            field = objType.GetProperty(name, flags);
            objType = objType.BaseType;
        }
        return (T)field.GetValue(obj, null);
    }
