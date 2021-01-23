    private void OnClicked(IList<DataGridCellInfo> selectedCells)
    {
        if(selectedCells.Count == 1)
        {
            var selectedColumnHeader = selectedCells[0].Column.Header.ToString();
        }
    }
