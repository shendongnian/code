    private void grdChoice_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == grdChoice.Columns["yesbutton"].Index)
        {
            ((Button)((DataGridView)sender).CurrentCell.Value).PerformClick();
        }
    }
