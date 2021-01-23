    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        if (row.Selected)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                int index = cell.ColumnIndex;
                if (index == 0)
                {
                    value = cell.Value.ToString();
                    //do what you want with the value
                }
            }
        }
    }
