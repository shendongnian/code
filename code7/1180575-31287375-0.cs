    ...
    foreach (var prop in b.GetProperties(BindingFlags.Public | BindingFlags.Instance))
    {
        var propName = prop.Name;
        if (!overriddenvalues.ContainsKey(propName))
        {
            var value = prop.GetValue(b,null);
            if (value != null)
            {
                overriddenvalues.Add(propName, value);
            }
        }
    }
    ...
