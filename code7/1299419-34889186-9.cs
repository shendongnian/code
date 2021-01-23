    var result =
        from table in DefaultSchema
        join myTable in MyTables on table.Name equals myTable.Name into matchingTables
        from matchingTable in matchingTables.DefaultIfEmpty()
        select new
        {
            Name = table.Name,
            MissingColumns = matchingTable == null
                ? null
                : table.Columns.Except(matchingTable.Columns, new ColumnComparer())
        };
