    private int column0MaxWidth = 100;
    this.dataGridView1.Columns[0].Width = 55;
    this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    // For contrast - column 1 contains the same data but is autosized.
    this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
    // On cell formatting, change a cell to single-lined or multilined.
    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewTextBoxCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewTextBoxCell;
      if (cell != null && e.ColumnIndex == 0)
      {
        cell.Style.WrapMode = TextRenderer.MeasureText(cell.Value.ToString(), cell.Style.Font).Width > column0MaxWidth ? DataGridViewTriState.True : DataGridViewTriState.NotSet;
      }
    }
