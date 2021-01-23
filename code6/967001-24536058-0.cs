    /// <summary>
    /// Generate a single column for the grid.
    /// </summary>
    /// <param name="dataField">The desired data field for the column.</param>
    /// <param name="name">The desired display field of the column.</param>
    /// <returns></returns>
    private void CreateColumn(GridTableView tableView, string dataField, string name, bool isVisible = true)
    {
        GridBoundColumn boundColumn = new GridBoundColumn();
        tableView.Columns.Add(boundColumn);
        boundColumn.DataField = dataField;
        boundColumn.UniqueName = name.Replace("'", "");
        boundColumn.HeaderText = Server.HtmlEncode(name);
        boundColumn.Visible = isVisible;
    }
