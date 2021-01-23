    private void invTableDataGridView_CellFormatting(Object sender,
                                                     DataGridViewCellFormattingEventArgs e)
    {
        Int32 yourindexColumn = 2;
        if (e.RowIndex < 0 || e.ColumnIndex <> yourindexColumn)
            Return;
        //Compare value and change color
        if (row.Cells[yourindexColumn].Value.ToString().Equals("Pharmacy") == true)
        {
            invTableDataGridView.DefaultCellStyle.BackColor = Color.Red;
        }
    }
