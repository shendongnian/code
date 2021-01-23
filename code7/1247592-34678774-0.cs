    private void DataGrid_PreviewKeyUp(object sender, KeyEventArgs e)
    {
        if ((e.Key == Key.Enter) || (e.Key == Key.Return))
        {
            DataGrid grid = sender as DataGrid;
            if (grid.CurrentColumn.Header.ToString().Equals("Barcode", StringComparison.OrdinalIgnoreCase))
            {
                if (grid.SelectionUnit == DataGridSelectionUnit.Cell || grid.SelectionUnit == DataGridSelectionUnit.CellOrRowHeader)
                {
                    var focusedElement = Keyboard.FocusedElement as UIElement;
                    focusedElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
                 }
                 grid.BeginEdit();
                 e.Handled = true;
            }
        }
    }
