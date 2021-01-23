    private void gradesDataGridView_CellFormatting(
                                     object sender, DataGridViewCellFormattingEventArgs e)
    {
       if (e.ColumnIndex == yourBottonColumnIndex )
       {
         Button btn = gradesDataGridView[yourBottonColumnIndex , e.RowIndex].Value as Button;
         if (btn != null) e.Value = btn.Text;
       }
    }
