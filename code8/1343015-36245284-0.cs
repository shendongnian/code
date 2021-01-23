    var lastColumn = datagridview.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.Visible).Name;
    var columnsList = datagridview.Columns
                .Cast<DataGridViewColumn>()
                .Select(c => c.Name)
                .Except(new[] { lastColumn });
