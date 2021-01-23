    private void invTableDataGridView_CellFormatting(Object sender,
                                                     DataGridViewCellFormattingEventArgs e)
    {
        Int32 yourindexColumn = 2;
        if (e.RowIndex < 0 || e.ColumnIndex <> yourindexColumn)
            Return;
        //Compare value and change color
        DataGridViewCell cell = invTableDataGridView.Rows(e.RowIndex).Cells[yourindexColumn]
        String value = cell.Value == null ? string.Empty : cell.Value.ToString()
        if (value.ToLowerCase().Equals("pharmacy") == true)
        {
            invTableDataGridView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red;
        }
    }
