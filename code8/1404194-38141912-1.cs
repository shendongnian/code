    void editDgvEc_TextChanged(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentCell.RowIndex == 0)
        {
            string search = dataGridView1.CurrentCell.Value.ToString();
            search = editDgvEc.Text;
            int col = dataGridView1.CurrentCell.ColumnIndex;
            if (search == "") dataGridView1.ClearSelection();
            else
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index == 0) continue;
                    row.Selected = row.Cells[col].Value.ToString().Contains(search);
                }
        }
    }
