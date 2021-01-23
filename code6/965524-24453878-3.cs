    public static IEnumerable<TableRow> AllRows(this Table table)
    {
         yield return new TableRow(table, table.Header);
         foreach(var row in table.Rows)
         {
             yield return row;
         }
     }
