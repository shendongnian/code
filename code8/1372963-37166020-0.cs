    foreach (var property in data.GetType().GetProperties())
    {
        if (!property.CanRead) continue;
        if (property.GetIndexParameters().Length > 0) continue;
        string name = property.Name;
        object value = property.GetValue(data, null);
        ...
    }
