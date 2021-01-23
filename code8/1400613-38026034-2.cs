    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        var insertedValue = (dataGridView1[e.ColumnIndex, e.RowIndex].Value ?? "").ToString();
    
        dataGridView1.Rows.Cast<DataGridViewRow>()
            .Where
            (   
                x => (x.Cells["ColumnID"].Value ?? "").ToString() == insertedValue
                && x.Index != e.RowIndex
            )
            .ToList()
            .ForEach(x => MessageBox.Show("Your Value is duplicated"));
    }
