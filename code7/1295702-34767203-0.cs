    var col0 = new DataGridViewTextBoxColumn
        {
            HeaderText = "#", Name="RowNum", 
            ReadOnly = true, 
            Width = 10
        };
    dgSSW.Columns.Insert(0, col0);
    dgSSW.CellFormatting += GridCellFormatting;
    private void GridCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgSSW.Columns[e.ColumnIndex].Name == "RowNum")
        {
            e.Value = (e.RowIndex + 1).ToString();
        }
    }
