    void dataGridView1_CellFormatting(object sender, 
                                      DataGridViewCellFormattingEventArgs e) {
      if (e.RowIndex == dataGridView1.Rows.Count - 1) {
        if (e.ColumnIndex == 1) {  // Your Button Column
          e.Value = "Add Row";
        }
      }
    }
