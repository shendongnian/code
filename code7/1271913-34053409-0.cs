    PropertyInfo[] properties = typeof(overDueItem).GetProperties();
    foreach (PropertyInfo property in properties)
    {
        var value = property.GetValue(overDueItem);
        ...
    }
