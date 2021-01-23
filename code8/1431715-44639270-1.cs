    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
    using (var bcp = new SqlBulkCopy(conn))
    using (var rd = ObjectReader.Create(myClassList))))
    {
        Type type = typeof(T);
        var accessor = TypeAccessor.Create(type);
        var members = accessor.GetMembers();
    
        foreach (var member in members)
        {
            bcp.ColumnMappings.Add(new SqlBulkCopyColumnMapping(member.Name, member.Name));
        }
        conn.Open();
   
        bcp.BatchSize = 10000;
        bcp.DestinationTableName = "myTable";
    
        bcp.WriteToServer(rd);
    }
