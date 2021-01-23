    private void ApplyChanges<F, S>(F originalEntity, S newEntity)
    {
        var entityType = typeof(F);
        var entityProperties = entityType.GetProperties();
        foreach (var propertyInfo in entityProperties
            // Filter scalar properties
            .Where(pi => pi.PropertyType.IsValueType || pi.PropertyType == typeof(string)))
        {
            var currentProperty = entityType.GetProperty(propertyInfo.Name);
            currentProperty.SetValue(originalEntity, propertyInfo.GetValue(newEntity, null));
        }
    }
