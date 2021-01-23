    var columnsInDisplayOrder = Results.Columns
        .Cast<DataGridViewColumn>()
        .Where(x => x.Visible)
        .OrderBy(x => x.DisplayIndex);
    foreach (DataGridViewColumn c in columnsInDisplayOrder)
    {
        MessageBox.Show(c.HeaderText);
    }
