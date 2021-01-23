    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        // Data of inserted value
        var rowIndex = e.RowIndex;
        var colIndex = e.ColumnIndex;
        var insertedValue = (dataGridView1[colIndex, rowIndex].Value ?? "").ToString();
    
        foreach(DataGridViewRow row in dataGridView1.Rows)
        {
            // If current cell == insertedValue but not the same row
            if((row.Cells["ColumnID"].Value ?? "").ToString() == insertedValue && row.Index != rowIndex)
            {
                MessageBox.Show("Your Value is duplicated");
            }
        }
    }
