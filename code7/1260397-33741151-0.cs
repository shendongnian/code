        estimateGridView.CellFormatting += estimateGridView_CellFormatting;
    
        private void estimateGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          DataGridViewCell cell = estimateGridView[e.ColumnIndex, e.RowIndex];
          cell.Style.BackColor = cell.ReadOnly ? Color.Gray : Color.White;
        }
