        private void button1_Click(object sender, EventArgs e)
        {
            // Getting data from DataGridView
            DataTable myDt = new DataTable();
            myDt = GetDTfromDGV(dataGridView1);
            // Writing to sql
            WriteToSQL(myDt);
        }
        private DataTable GetDTfromDGV(DataGridView dgv)
        {
            // Macking our DataTable
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                dt.Columns.Add(column.Name, typeof(string));
            }
            // Getting data
            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int col = 0; col < dgv.Columns.Count; col++)
                {
                    dr[col] = dgvRow.Cells[col].Value;
                }
                dt.Rows.Add(dr);
            }
            // removing empty rows
            for (int row = dt.Rows.Count - 1; row >= 0; row--)
            {
                bool flag = true;
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    if (dt.Rows[row][col] != DBNull.Value)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == true)
                {
                    dt.Rows.RemoveAt(row);
                }
            }
            return dt;
        }
        private void WriteToSQL(DataTable dt)
        {
            string connectionStringSQL = "Your connection string";
            using (SqlConnection sqlConn = new SqlConnection(connectionStringSQL))
            {
                SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConn);
                // Setting the database table name
                sqlBulkCopy.DestinationTableName = "Table_1_temp";
                // Mapping the DataTable columns with that of the database table
                sqlBulkCopy.ColumnMappings.Add(dt.Columns[0].ColumnName, "sql_col1");
                sqlBulkCopy.ColumnMappings.Add(dt.Columns[1].ColumnName, "sql_col2");
                sqlBulkCopy.ColumnMappings.Add(dt.Columns[2].ColumnName, "sql_col3");
                sqlBulkCopy.ColumnMappings.Add(dt.Columns[3].ColumnName, "sql_col4");
                sqlBulkCopy.ColumnMappings.Add(dt.Columns[4].ColumnName, "sql_col5");
                sqlBulkCopy.ColumnMappings.Add(dt.Columns[5].ColumnName, "sql_col6");
                sqlConn.Open();
                sqlBulkCopy.WriteToServer(dt);
            }
        }
