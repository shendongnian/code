    DataTable table = new DataTable();
    // create the columns 
    DataColumn firstNameColumn = new DataColumn();
    firstNameColumn.DataType = System.Type.GetType("System.String");
    firstNameColumn.ColumnName = "FirstName";
    firstNameColumn.DefaultValue = string.Empty;
    DataColumn lastNameColumn = new DataColumn();
    lastNameColumn.DataType = System.Type.GetType("System.String");
    lastNameColumn.ColumnName = "LastName";
    lastNameColumn.DefaultValue = string.Empty;
    DataColumn addressColumn = new DataColumn();
    addressColumn.DataType = System.Type.GetType("System.String");
    addressColumn.ColumnName = "Address";
    addressColumn.DefaultValue = string.Empty;
    // this column uses an Expression to concatenate others together in comma delim
    DataColumn concatColumn = new DataColumn();
    concatColumn.DataType = System.Type.GetType("System.String");
    concatColumn.ColumnName = "Concatenated";
    concatColumn.Expression = "FirstName + ', ' + LastName + ', ' + Address"; 
    // add columns to DataTable 
    table.Columns.Add(firstNameColumn);
    table.Columns.Add(lastNameColumn);
    table.Columns.Add(addressColumn);
    table.Columns.Add(concatColumn); 
    // add some rows
    DataRow row1 = table.NewRow();
    row1["FirstName"] = "John";
    row1["LastName"] = "Doe";
    row1["Address"] = "123 East Street";
    table.Rows.Add(row1);
    DataRow row2 = table.NewRow();
    row2["FirstName"] = "Bill";
    row2["LastName"] = "Smith";
    row2["Address"] = "444 North Avenue";
    table.Rows.Add(row2); 
    // simple iteration to print out the concatenated column
    foreach (DataRow dr in table.Rows)
       Console.WriteLine(dr["Concatenated"]);
