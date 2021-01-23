            string SelectQuery = "SELECT * FROM [tableName]";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConnectionString))
            {
                using (var da = new SqlDataAdapter(SelectQuery, con))
                {
                    //Populate the datatable with the results
                    da.Fill(table);
                }
            }
