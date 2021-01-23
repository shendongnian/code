    private void gv_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == gv.Columns["ColumnMark"].Index)
        {
            if ((bool)gv.Rows[e.RowIndex].Cells["ColumnMark"].Value)
            {
                if (authorized == "TRUE")
                {
                    gv.Rows[e.RowIndex].Cells["ColumnMark"].Value = 0;
                }
                else
                {
                    gv.Rows[e.RowIndex].Cells["ColumnMark"].Value = 1;
                }
            }
            else
            {
                gv.Rows[e.RowIndex].Cells["ColumnMark"].Value = 1;
            }
            gv.RefreshEdit();
            gv.NotifyCurrentCellDirty(true);
            DisplayItemTotalAmount();
        }
    }
    private void gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        gv.RefreshEdit();
    }
