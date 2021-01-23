    private void GridMainElements_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Debug.WriteLine("Selected cells changed");
            if(e != null && e.AddedCells != null && e.AddedCells.Count == 1)
            {
                DataGridCellInfo selectedCell = e.AddedCells[0];
                if(selectedCell.Column == ColumnFormula || selectedCell.Column == ColumnNote)
                {
                    GridMainElements.BeginEdit();
                }
            }
        }
