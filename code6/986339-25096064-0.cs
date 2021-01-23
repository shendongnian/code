    if ( usingSchema1 )
    {
        modelBuilder.Configurations.Add(new Entity1Schema1Map());
    }
    else
    {
        modelBuilder.Configurations.Add(new Entity1Schema2Map());
    }
