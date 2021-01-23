    String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
        "Data Source=" + TextBox1.Text + ";" +
        "Extended Properties=Excel 8.0;";
    using (OleDbConnection excel_con = new OleDbConnection(connectionString ))
    {
        excel_con.Open();
        string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
        DataTable dtExcelData = new DataTable();
 
        //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
        dtExcelData.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("Password",typeof(string)) });
 
        using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
        {
            oda.Fill(dtExcelData);
        }
        excel_con.Close();
 
        string consString = MyConString;
        using (SqlConnection con = new SqlConnection(consString))
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            {
                //Set the database table name
                sqlBulkCopy.DestinationTableName = "dbo.TableName";
                sqlBulkCopy.ColumnMappings.Add("Id", "Id");
                sqlBulkCopy.ColumnMappings.Add("Password", "Password");
                sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                con.Open();
                sqlBulkCopy.WriteToServer(dtExcelData);
                con.Close();
                MessageBox.Show("Upload Successfull!");
            }
        }
    }
