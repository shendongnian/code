    private void button1_Click(object sender, EventArgs e)
        {
            // Getting data from DataGridView
            DataTable myDt = new DataTable();
            myDt = GetDTfromDGV(dataGridView1);
        }
    private DataTable GetDTfromDGV(DataGridView dgv)
        {
            // Macking our DataTable
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6]
                {
                    new DataColumn(dt.Columns[0].ColumnName, typeof(string)),
                    new DataColumn(dt.Columns[1].ColumnName, typeof(string)),
                    new DataColumn(dt.Columns[2].ColumnName, typeof(string)),
                    new DataColumn(dt.Columns[3].ColumnName, typeof(string)),
                    new DataColumn(dt.Columns[4].ColumnName, typeof(int)),
                    new DataColumn(dt.Columns[4].ColumnName, typeof(int))
                });
            // Getting data
            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int col = 0; col < dgv.Columns.Count; col++)
                {
                    dr[col] = dgvRow.Cells[col].Value == null ? DBNull.Value : dgvRow.Cells[col].Value;
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
