    public static void PropertyMap<T, U>(T source, U destination)
        where T : class, new()
        where U : class, new()
    {
        List<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToList<PropertyInfo>();
        List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList<PropertyInfo>();
        foreach (PropertyInfo sourceProperty in sourceProperties)
        {
            PropertyInfo destinationProperty = destinationProperties.Find(item => item.Name == sourceProperty.Name);
            if (destinationProperty != null)
            {
                if (sourceProperty.PropertyType == destinationProperty.PropertyType &&
                    simpleTypes.Contains(sourceProperty.PropertyType) &&
                    simpleTypes.Contains(destinationProperty.PropertyType))
                {
                    // set the value of the simple type directly
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
                }
                else
                {
                    // complex object => we start by instantiating it which will
                    // of course crash if the target type doesn't have a 
                    // default constructor
                    var destInstance = Activator.CreateInstance(destinationProperty.PropertyType);
                    destinationProperty.SetValue(destination, destInstance, null);
                    // recurse down the object graph
                    PropertyMap(sourceProperty.GetValue(source, null), destInstance);
                }
            }
        }
    }
    private static readonly Type[] simpleTypes = new[]
    {
        typeof(string),
        typeof(ushort),
        typeof(uint),
        typeof(ulong),
        typeof(short),
        typeof(int),
        typeof(long),
        typeof(float),
        typeof(decimal),
        typeof(double),
        typeof(DateTime),
        typeof(TimeSpan),
        // Make sure I haven't forgot some other simple types
    };
