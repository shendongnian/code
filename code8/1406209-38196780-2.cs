    // Project each list item into an array of item property values
    var array4all = list.Select
    (
        item => item.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                              .Select(property => property.GetValue(item))
                              .ToArray()
    ).ToArray();
