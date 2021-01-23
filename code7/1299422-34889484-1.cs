    var diffs = new List<Table>();
    
    foreach( Table table in MyTables )
    {
        Table schema = DefaultSchema
            // consider case insensitive comparison if needed.
            .FirstOrDefault( x => x.Name == table.Name );
    
        if( schema == null )
        {
            // no matching schema, everything should be evaluated.
            diffs.Add( table );
            continue;
        }
    
        // use IEquatable to pull out the differences
        List<Column> columns = table.Columns.Except( schema.Columns ).ToList();
    
        if( columns.Any() )
        {
            diffs.Add( new Table { Name = table.Name, Columns = columns } );
        }
    }
