            using (OleDbConnection _connection = new OleDbConnection())
            {
                var ConnectionString = new StringBuilder("");
                ConnectionString.Append(@"Provider=Microsoft.Jet.OLEDB.4.0;");
                ConnectionString.Append(@"Extended Properties=Paradox 5.x;");
                ConnectionString.Append(@"Data Source=D:\dbf;");
                _connection.ConnectionString = ConnectionString.ToString();
                _connection.Open();
                using (OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM table.db;", _connection))
                {
                    using (DataSet dsRetrievedData = new DataSet())
                    {
                        da.Fill(dsRetrievedData);
                        dataGridView1.DataSource = dsRetrievedData;
                        dataGridView1.DataMember = dsRetrievedData.Tables[0].TableName;
                    }
                }
            }
