    private DataTable GetDTfromDGV(DataGridView dgv)
        {
            // Macking our DataTable
            DataTable dt = new DataTable();
            //Another way to add columns
            dt.Columns.AddRange(new DataColumn[5]
                {
                    //new DataColumn("table_ID", typeof(string)), if table_ID is not Identity column with auto increment then uncomment
                    new DataColumn("sql_col2", typeof(string)),
                    new DataColumn("sql_col3", typeof(string)),
                    new DataColumn("sql_col4", typeof(string)),
                    new DataColumn("Table_2_ID", typeof(int)),
                    new DataColumn("Table_3_IDt", typeof(int))
                });
            // Getting data
            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int col = 1; col < dgv.Columns.Count; col++) //if table_ID is not Identity column with auto increment then start with 0
                {
                    dr[col - 1] = dgvRow.Cells[col].Value == null ? DBNull.Value : dgvRow.Cells[col].Value;
                }
                dt.Rows.Add(dr);
            }
            // removing empty rows
            ....
            return dt;
        }
        private void WriteToSQL(DataTable dt)
        {
            string connectionStringSQL = "Your connection string";
            using (SqlConnection sqlConn = new SqlConnection(connectionStringSQL))
            {
                SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConn);
                // Setting the database table name
                sqlBulkCopy.DestinationTableName = "Table_1";
                // Mapping the DataTable columns with that of the database table
                //sqlBulkCopy.ColumnMappings.Add(dt.Columns[0].ColumnName, "table_ID"); table_ID is Identity column with auto increment
                sqlBulkCopy.ColumnMappings.Add(dt.Columns[0].ColumnName, "sql_col2");
                sqlBulkCopy.ColumnMappings.Add(dt.Columns[1].ColumnName, "sql_col3");
                sqlBulkCopy.ColumnMappings.Add(dt.Columns[2].ColumnName, "sql_col4");
                sqlBulkCopy.ColumnMappings.Add(dt.Columns[3].ColumnName, "Table_2_ID");
                sqlBulkCopy.ColumnMappings.Add(dt.Columns[4].ColumnName, "Table_3_ID");
                sqlConn.Open();
                sqlBulkCopy.WriteToServer(dt);
            }
        }
