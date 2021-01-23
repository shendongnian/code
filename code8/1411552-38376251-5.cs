    public void CompareNewWithOld(object oldObject, object newObject, List<object> added, List<object> removed)
    {
        var properties = typeof (SomeClass).GetProperties();
        foreach (PropertyInfo pi in properties)
        {
            object oldValue = pi.GetValue(oldObject), newValue = pi.GetValue(newObject);
            if (pi.PropertyType.IsGenericType && typeof(IEnumerable).IsAssignableFrom(pi.PropertyType))
            {
                var itemType = pi.PropertyType.GetGenericArguments()[0];
                var itemKeyProperty = itemType
                    .GetProperties()
                    .FirstOrDefault(ipi => ipi.GetCustomAttribute<KeyAttribute>() != null);
                if (itemKeyProperty == null)
                {
                    continue; // no Key property -- cannot compare
                }
                var comparer = new ItemByKeyEqualityComparer(itemKeyProperty);
                HashSet<object> oldSet = new HashSet<object>(((IEnumerable)oldValue).Cast<object>(), comparer);
                HashSet<object> newSet = new HashSet<object>(((IEnumerable)newValue).Cast<object>(), comparer);
                HashSet<object> removedSet = new HashSet<object>(oldSet, comparer);
                removedSet.ExceptWith(newSet);
                HashSet<object> addedSet = new HashSet<object>(newSet, comparer);
                addedSet.ExceptWith(oldSet);
                added.AddRange(addedSet);
                removed.AddRange(removedSet);
            }
        }
    }
