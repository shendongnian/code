    private void UpdateWidths()
    {
        foreach (var column in this._gridView.Columns)
        {
            column.Width = column.ActualWidth;
            column.Width = Double.NaN;
        }
    }
