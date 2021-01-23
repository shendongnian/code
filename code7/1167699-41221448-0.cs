            OleDbConnection connection = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=\"Excel 8.0;HDR=No;\"", filePath));
            OleDbCommand command = new OleDbCommand();
            DataTable tableOfData = null;
            command.Connection = connection;
            try
            {
                connection.Open();
                tableOfData = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string tablename = tableOfData.Rows[0]["TABLE_NAME"].ToString();
                tableOfData = new DataTable();
                command.CommandText = "Select * FROM [" + tablename + "]";
                tableOfData.Load(command.ExecuteReader());
            }
            catch (Exception ex)
            {
            }
