    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T SetProperty<T>(ref T destination, string propertyName, object value)
    {
        var type = destination.GetType();
        var property = type.GetProperty(propertyName);
        var convertedVal = Convert(value, property.PropertyType);
        object boxed = destination;
        property.SetValue(boxed, convertedVal);
        destination = (T) boxed;
        return (T)boxed;
    }
