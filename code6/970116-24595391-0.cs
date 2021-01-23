    public static void UpdateObject<T>(this T source, T target)
    {
        var type = typeof(T);
        var properties = type.GetProperties();
        foreach(var prop in properties)
            prop.SetValue(source, prop.GetValue(target));
    }
    // Usage:
    preConObj.UpdateObject(postConObj);
