       public void testeStackOverflow()
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = this.ConnectionString;
                string server = builder.DataSource;
                string database = builder.InitialCatalog;
                connection.Open();
                DataTable schemaTables = connection.GetSchema("Tables");
                
                foreach (System.Data.DataRow rowTable in schemaTables.Rows)
                {
                    String TableName = rowTable.ItemArray[2].ToString();
                    string[] restrictionsColumns = new string[4];
                    restrictionsColumns[2] = TableName;
                    DataTable schemaColumns = connection.GetSchema("Columns", restrictionsColumns);
                    foreach (System.Data.DataRow rowColumn in schemaColumns.Rows)
                    {
                        string ColumnName = rowColumn[3].ToString();
                    }
                }
            }
        }
