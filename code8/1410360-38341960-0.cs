    SqlDataAdapter dataAdapter = new SqlDataAdapter();
    DataTable dataTable = new DataTable();
    DataRow dataRow = dataTable.NewRow(); 
    insertRecord = new SqlCommand(proc, connectString.UConnect);
    insertRecord.CommandType = CommandType.StoredProcedure;
    //this collects the paramters, data type, and column length
    for (int x = 0; x < columnName.Length; x++)
       insertRecord.Parameters.Add("@" + columnName[x], SqlDbType.VarChar, 0, param[x]).Value = value[x];
    //this collects the rows to be added
    for (int x = 0; x < columnName.Length; x++)
       dataRow[columnName[x]] = value[x];
    dataTable.Rows.Add(dataRow);
    dataAdapter.InsertCommand = insertRecord;
    dataAdapater.Update(dataTable);
