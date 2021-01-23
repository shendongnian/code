    void RecursiveMethod( Table table, List<string> visitedTables )
    {
        // note the currently visited table
        var extendedList = visitedTables.ToList();
        extendedList.Add( table.Name );
        // do your thing with the table...
        // ... and recurse deeper
        foreach (var referencedTable in table.ReferencedTables)
            if (!visitedTables.Contains( referencedTable.Name ))
                RecursiveMethod( referencedTable, extendedList );
    }
