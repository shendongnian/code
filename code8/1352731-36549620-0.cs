    // Your property to get the current state from.
    public bool IsChecked = false;
    
    private void RowSelected()
    {
        // Count all selected cells that have the same row-index as the first cell.
        int cellsSelected = datagridview.SelectedCells.Cast<DataGridViewCell>().Select(x => x).Where(x => x.RowIndex == datagridview.SelectedCells[0].RowIndex).Count();
        // If count of cells == count of columns -> all cells are selected.
        IsChecked = (cellsSelected == datagridview.Columns.Count) ? true : false;
    }
    
    public void DataGridView_SelectionChanged(object sender, EventArgs e)
    {
        // Will take care for the switch.
        RowSelected();
    }
