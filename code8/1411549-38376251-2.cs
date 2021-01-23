    foreach (PropertyInfo pi in properties)
    {
        object oldValue = pi.GetValue(oldObject), newValue = pi.GetValue(newObject);
        if (pi.PropertyType.IsGenericType && typeof(IEnumerable).IsAssignableFrom(pi.PropertyType))
        {
            HashSet<object> oldSet = new HashSet<object>(((IEnumerable)oldValue).Cast<object>());
            HashSet<object> newSet = new HashSet<object>(((IEnumerable)newValue).Cast<object>());
            HashSet<object> removed = new HashSet<object>(oldSet);
            removed.ExceptWith(newSet);
            HashSet<object> added = new HashSet<object>(newSet);
            added.ExceptWith(oldSet);
        }
    }
