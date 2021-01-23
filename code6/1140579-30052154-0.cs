    var columnsInDisplayOrder = Results.Columns
        .Cast<DataGridViewColumn>()
        .OrderBy(x => x.DisplayIndex);
    foreach (DataGridViewColumn c in columnsInDisplayOrder)
    {
        MessageBox.Show(c.HeaderText);
    }
