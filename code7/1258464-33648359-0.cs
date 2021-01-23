    var getValue = GetPrivateProperty<bool>(class, "BoolProperty");
    public static T GetPrivateProperty<T>(object obj, string name)
    {
        BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        PropertyInfo field = obj.GetType().GetProperty(name, flags);
        return (T)field.GetValue(obj, null);
    }
