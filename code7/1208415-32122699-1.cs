    foreach (var property in names)
    {
        var m = entry.Member(property.Name);
        if (m is DbPropertyEntry)//simple property
        {
             var p = entry.Property(property.Name);
        }
        if (m is DbReferenceEntry)//navigation to single object
        {
             var r = entry.Reference(property.Name);
        }
        if (m is DbCollectionEntry)//navigation to collection
        {
             var c = entry.Collection(property.Name);
        }
    }
