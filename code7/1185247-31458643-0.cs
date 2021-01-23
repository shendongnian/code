        int SelectedRowIndex;
        private void InitDGVData()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            DataColumn dc1 = new DataColumn();
            dt.Columns.Add(dc);
            dt.Columns.Add(dc1);
            for (int i = 0; i < 10000; i++)
            {
                dt.Rows.Add(i.ToString(), i.ToString());
            }
            dataGridView1.DataSource = dt;
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.Name = "Selected";
            dataGridView1.Columns.Add(col);
            SelectedRowIndex = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows[SelectedRowIndex].Cells[dataGridView1.Columns["Selected"].Index].Value = true;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Selected"].Index && e.RowIndex != SelectedRowIndex)
            {
                dataGridView1.Rows[SelectedRowIndex].Cells[dataGridView1.Columns["Selected"].Index].Value = false;
                SelectedRowIndex = e.RowIndex;
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[SelectedRowIndex].Cells[dataGridView1.Columns["Selected"].Index].Value = true;
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Selected"].Index && e.RowIndex == SelectedRowIndex)
            e.Cancel = true;
        }
