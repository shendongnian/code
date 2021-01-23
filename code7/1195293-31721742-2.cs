    set
    {
        PropertyInfo property = GetType().GetProperty(propertyName);
        Type type = property.GetType();
        // Treat nullable types as their underlying types.
        type = Nullable.GetUnderlyingType(type) ?? type;
        // TODO: Move this to a static readonly field. No need to
        // create a new one each time
        IFormatProvider culture = new CultureInfo("fr-FR", true);
        if (type == typeof(System.DateTime))
        {
            property.SetValue(this, Convert.ToDateTime(value, culture), null);
        }
        else if (type == typeof(int))
        {
            property.SetValue(this, Int32.Parse((string)value));
        }
        else
        {
            property.SetValue(this, value, null);
        }
    }
