    var metadata = ((IObjectContextAdapter)db).ObjectContext.MetadataWorkspace;
    var tables = metadata.GetItemCollection(DataSpace.SSpace)
                         .GetItems<EntityContainer>().Single()
                         .BaseEntitySets
                         .OfType<EntitySet>()
                         .Where(s => !s.MetadataProperties.Contains("Type") || s.MetadataProperties["Type"].ToString() == "Tables");
    
    foreach (var table in tables)
    {
        Console.WriteLine(string.Format("{0}.{1}", table.Schema, table.Name));
        foreach (var member in table.ElementType.Members)
        {
            var column = string.Format("    {0}, Nullable: {1}",
                member.Name,
                ((TypeUsage)member.MetadataProperties["TypeUsage"].Value).Facets["Nullable"].Value);
            Console.WriteLine(column);
        }
    }
