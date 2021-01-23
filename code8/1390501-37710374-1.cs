    private HashSet<int> checkedRowIndexes = new HashSet<int>();
    
    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if ( e.ColumnIndex == CheckBoxColumn1.Index ) 
        {
            if ( true.Equals( dataGridView1[CheckBoxColumn1.Index, e.RowIndex].Value ) )
                checkedRowIndexes.Add(e.RowIndex);
            else 
                checkedRowIndexes.Remove(e.RowIndex);
        }
    }
