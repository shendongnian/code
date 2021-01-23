    private DataTable NoMatches (DataTable MainTable, DataTable SecondaryTable)
    {
        var matched = from table1 in MainTable.AsEnumerable()
                      join table2 in SecondaryTable.AsEnumerable()
                      on table1.Field<string>("ColumnA") equals table2.Field<string>("ColumnC") 
                      where (table1.Field<string>("ColumnB").Equals(table2.Field<string>("ColumnA"))) 
                      || (table1.Field<int>("ColumnC") == table2.Field<int>("ColumnD")) 
                      select table1;
        return MainTable.AsEnumerable().Except(matched).CopyToDataTable();
    }
