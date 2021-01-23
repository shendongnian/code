    var column = DataColumn("UniqueRow", typeof(System.String));
    products.Columns.Add(column );
    
    foreach(DataRow row in DataTable.Rows)
    {
        row[column] = Guid.NewGuid(); // or any other id 
    }
