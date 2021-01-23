    public static object GetPropertyValue (object o, string path)
    {
        object value = o;
        string[] pathComponents = path.Split (new char[]{'.'}, StringSplitOptions.RemoveEmptyEntries);
        if (pathComponents.Length == 1) {
            return value.GetType().GetProperty(pathComponents [0]).GetValue (o, null);
        }
        foreach (var component in pathComponents) {
            value = value.GetType().GetProperty (component).GetValue (value, null);
        }
        return value;
    }
