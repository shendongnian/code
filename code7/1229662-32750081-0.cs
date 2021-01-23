    public string GetSelectedCellValue()
    {
        DataGridCellInfo cells = MyDataGrid.SelectedCells[0];
        YourRowClass item = cells.Item as YourRowClass;
        string columnName = cells.Column.SortMemberPath;
        if (item == null || columnName == null) return null;
        object result = item.GetType().GetProperty(columnName).GetValue(item, null);
        if (result == null) return null;
        return result.ToString();
    }
