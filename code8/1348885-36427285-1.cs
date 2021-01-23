    public static IEnumerable<T> Trim<T>(this IEnumerable<T> collection)
        where T:class 
    {
        foreach (var item in collection)
        {
            var properties = item.GetType().GetProperties();
            // Loop over properts
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof (string))
                {
                    var currentValue = (string)property.GetValue(item);
                    if (currentValue != null)
                        property.SetValue(item, currentValue.Trim());
                }
                else if (typeof(IEnumerable<object>).IsAssignableFrom(property.PropertyType))
                {
                    var currentValue = (IEnumerable<object>)property.GetValue(item);
                    if (currentValue != null)
                        currentValue.Trim();
                }
            }
        }
        return collection;
    }
