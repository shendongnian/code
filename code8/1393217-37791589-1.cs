    var columns = dt.Columns.Cast<DataColumn>()
                    .Where(x => x.DataType == typeof(bool))
                    .Select(x => new
                    {
                        Column = x,
                        Count = dt.Rows.Cast<DataRow>()
                                    .Count(r => r.Field<bool>(x) == true)
                    }).OrderByDescending(x => x.Count)
                    .Select(x => x.Column).ToList();
    columns.ForEach(x =>
    {
        var column = grid.Columns.Cast<DataGridViewColumn>()
                        .Where(c => c.DataPropertyName == x.ColumnName)
                        .FirstOrDefault();
        if (column != null)
        {
            grid.Columns.Remove(column);
            grid.Columns.Add((DataGridViewColumn)column.Clone());
            column.Dispose();
        }
    });
