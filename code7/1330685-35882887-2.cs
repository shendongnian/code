    var column = new DataColumn("UniqueRow", typeof(System.String));    
    products.Columns.Add(column );
    column.SetOrdinal(0); // first column 
    
    foreach(DataRow row in DataTable.Rows)
    {
        row[column] = Guid.NewGuid(); // or any other id 
    }
