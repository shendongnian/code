    DbDataReader dr = command.ExecuteReader();
    
    DataTable table = new DataTable("Customers");
    table.Load(dr);
    table.Columns.Add("StudentId", typeof(int));
    table.Columns.Add("BatchCode", typeof(string));
    table.Columns.Add("Email", typeof(string));
    
    foreach (DataRow row in table.Rows)
    {
        row["StudentId"] = GetStudentId(row);
        row["BatchCode"] = GetBatchCode(row);
        row["Email"] = GetEmail(row);
    }
                        
    
    // SQL Server Connection String
    string sqlConnectionString = @"Data Source=sample;Initial Catalog=ExcelImport;User ID=sample;Password=sample";
    
    // Bulk Copy to SQL Server 
    SqlBulkCopy bulkInsert = new SqlBulkCopy(sqlConnectionString);
    bulkInsert.DestinationTableName = "Customer_Table";
    bulkInsert.WriteToServer(table);
