    private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.ColumnIndex < 0 || e.RowIndex < 0 
         || dataGridView1[e.ColumnIndex, e.RowIndex].Value == null) return;
        // use your own function to set the text!
        string s = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
        // check for changes to prevent flicker!
        if (s == toolTip1.GetToolTip(dataGridView1)) return;
        
        toolTip1.SetToolTip(dataGridView1, s); 
    }
