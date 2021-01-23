    private void button1_Click(object sender, EventArgs e)
    {
        //SqlConnection connection = new SqlConnection("Data Source='server_name';Initial Catalog='database_name';Trusted_Connection=True;");
        DataTable dt = (DataTable)dataGridView1.DataSource;
        string connection = "Data Source=Excel-PC;Initial Catalog=Northwind.MDF;Trusted_Connection=True;";
        using (var conn = new SqlConnection(connection))
        {
            conn.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
            {
                bulkCopy.ColumnMappings.Add(0, "Fname");
                bulkCopy.ColumnMappings.Add(1, "Lname");
                bulkCopy.ColumnMappings.Add(2, "Age");
                bulkCopy.BatchSize = 10000;
                bulkCopy.DestinationTableName = "Import_List";
                bulkCopy.WriteToServer(dt.CreateDataReader());
            }
        }
    
    }
