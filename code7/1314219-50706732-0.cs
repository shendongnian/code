    private void ChangeCheckedStateOfOtherCheckboxesInDgv(object sender, DataGridViewCellEventArgs e)
    {
        const int chkBoxColumnIndex = 0;
    
        var dataGridView = (DataGridView)sender;
    
        if (e.ColumnIndex == chkBoxColumnIndex)
        {
            dataGridView.EndEdit();
    
            var isChecked = (bool)dataGridView[e.ColumnIndex, e.RowIndex].Value;
    
            if (isChecked)
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Index != e.RowIndex)
                        row.Cells[chkBoxColumnIndex].Value = !isChecked;
                }
            }
        }
    }
