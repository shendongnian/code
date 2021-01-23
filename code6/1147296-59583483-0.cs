    private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      var grid = (DataGridView)sender;
      if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
      {
        if (grid.RowCount >= 0)
        {
           //this needs to be altered for every DataGridViewButtonColumn with different Text
           grid.Rows[grid.RowCount - 1].Cells[e.ColumnIndex].Value = "ButtonText";
        }
      }
    }
    private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
      var grid = (DataGridView)sender;
      //this needs to be altered for every DataGridViewButtonColumn with different Text
      int buttonColumn = 3;
      if (grid.Columns[buttonColumn] is DataGridViewButtonColumn)
      {
        if (grid.RowCount >= 0)
        {
            grid.Rows[grid.RowCount - 1].Cells[buttonColumn].Value = "ButtonText";
        }
      }
    }
