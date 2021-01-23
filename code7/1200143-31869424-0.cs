    DataTable dt = new DataTable();
    foreach (DataGridViewColumn col in dataGridView1.Columns)
    {
        bool empty = false;
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (row.Cells[col.Index].Value.ToString() == string.Empty)
            {
                 empty = true;
            }
            break;
        }
        if (empty == false)
        {
            dt.Columns.Add(col.HeaderText);
        }
    }
