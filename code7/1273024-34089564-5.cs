    // Counter: keeps track of the order of the column inside the composite key
    var tableKeys = new Dictionary<Type,int>();
    modelBuilder.Properties<Guid>()
    .Where(p =>
    {
        // Break the entiy name in segments
        var segments = p.DeclaringType.Name.Split(new[] {"LK_","_LK_"},
                          StringSplitOptions.RemoveEmptyEntries);
        // if the property has a name like one of the segments, it's part of the key
        if (segments.Any(s => s + "ID" == p.Name))
        {
            //  If it's not already in the column counter, adds it
            if (!tableKeys.ContainsKey(p.DeclaringType))
            {
                tableKeys[p.DeclaringType] = 0;
            }
            // increases the counter
            tableKeys[p.DeclaringType] = tableKeys[p.DeclaringType] + 1;
            return true;
        }
        return false;
    })
    .Configure(a =>
    {
        a.IsKey();
        // use the counter to set the order of the column in the composite key
        a.HasColumnOrder(tableKeys[a.ClrPropertyInfo.DeclaringType]);
    });
