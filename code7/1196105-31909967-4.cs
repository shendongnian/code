    private void InsertDTtoDB(string ConnectionString, string TableName, DataGridView DGV)
    {
        DataTable dt = GetDataTableFromDGV(DGV);
        using (SqlConnection cn = new SqlConnection(ConnectionString))
        {
            cn.Open();
            using (SqlBulkCopy copy = new SqlBulkCopy(cn))
            {   
                // update the "DestinationCol[x]" values to the destination column names
                copy.ColumnMappings.Add("Invoice_Id", "DestinationCol1");
                copy.ColumnMappings.Add("Software_Id", "DestinationCol2");
                copy.ColumnMappings.Add("Price", "DestinationCol3");
                copy.ColumnMappings.Add("Quantity", "DestinationCol4");
                copy.ColumnMappings.Add("Sum", "DestinationCol5");
                copy.DestinationTableName = TableName;
                copy.WriteToServer(dt);
            }
        }
    }
