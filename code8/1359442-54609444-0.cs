    bool lastRowSelected = false;
    if (grid.SelectedCells != null)
    {
        foreach (DataGridViewCell cell in grid.SelectedCells)
        {
            if (cell.RowIndex >= grid.NewRowIndex)
            {
                lastRowSelected = true;
                break;
            }
        }
    }
