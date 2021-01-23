    foreach (var propToClone in toClone.GetType().
                  GetProperties(BindingFlags.Instance | BindingFlags.Public))
    {
        PropertyInfo propInfo = newCopy.GetType().GetProperty(propToClone.Name);
        if (propInfo.CanWrite)
            propInfo.SetValue(newCopy, propToClone.GetValue(toClone, null));
    }
