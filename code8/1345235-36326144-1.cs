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
                    new DataColumn(dgv.Columns[0].Name, typeof(string)),
                    new DataColumn(dgv.Columns[1].Name, typeof(string)),
                    new DataColumn(dgv.Columns[2].Name, typeof(string)),
                    new DataColumn(dgv.Columns[3].Name, typeof(string)),
                    new DataColumn(dgv.Columns[4].Name, typeof(int)),
                    new DataColumn(dgv.Columns[5].Name, typeof(int))
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
