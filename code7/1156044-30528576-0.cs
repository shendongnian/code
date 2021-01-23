    public static T[] FindWithTag<T>(string tag) where T : Control
    {
        List<T> types = new List<T>();
        foreach (T type in fm.Controls.OfType<T>())
            if (type.Tag == tag)
                types.Add(type);
        return types;
    }
