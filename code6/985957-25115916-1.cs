    private void grdVerdict_CellFormat(object sender, DataGridViewCellFormattingEventArgs e)
    {
       if (e.ColumnIndex == grdChoice.Columns["yesbutton"].Index)
       {
           e.Value = ((Button)grdChoice[e.ColumnIndex, e.RowIndex].Value).Text;
       }
    }
