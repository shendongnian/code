    if (property.PropertyType == typeof(string))
    {
        property.SetValue(item, valueToConvert.ToString());
    }
    else if (property.PropertyType == typeof(int))
    {
        property.SetValue(item, Convert.ToInt32(valueToConvert)].ToString()));
    }
    else if (property.PropertyType == typeof(bool))
    {
        property.SetValue(item, Convert.ToBoolean(valueToConvert.ToString()));
    }
    ...
