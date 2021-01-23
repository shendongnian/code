    private void Grid1_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
    {
        if (loading) return;
        
        try
        {
            _OriginalValue = Grid1[e.ColumnIndex, e.RowIndex].Value.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error occured.\nError message: " + 
            ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void Grid2_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
    {
       if (loading) return;
       try
       {
         DataGridViewCell cell = Grid2[e.ColumnIndex, e.RowIndex];
         if (cell.Value.ToString() != _OriginalValue)
         {
            if (version_Number >= 1000)
            {
               cell.Style.BackColor = Color.Yellow;
            }
        }  
        ..
        ..
