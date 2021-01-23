    public static class Extensions
    {
     public static DataTable ToDataTable(this IEnumerable<EmployeeView> source)
     {
        dataTable.Columns.Add(
                new DataColumn()
                 {
                     DataType = System.Type.GetType("System.String"),
                     ColumnName = "Name"
                 }
                );
                dataTable.Columns.Add(
                new DataColumn()
                 {
                     DataType = System.Type.GetType("System.String"),
                     ColumnName = "Address"
                 }
                );
                dataTable.Columns.Add(
                 new DataColumn()
                 {
                     DataType = System.Type.GetType("System.String"),
                     ColumnName = "Phone"
                 }
                );
                dataTable.Columns.Add(
                 new DataColumn()
                 {
                     DataType = System.Type.GetType("System.DateTime"),
                     ColumnName = "DateOfHire"
                 }
                );
    
                foreach (var elem in source)
                {
                    var row = dataTable.NewRow();
                    row["Name"] = elem.Name;
                    row["Address"] = elem.Address;
                    row["Phone"] = elem.Phone;
                    row["DateOfHire"] = elem.DateOfHire;
                    dataTable.Rows.Add(row);
                }
          return dataTable;
     }
    }
