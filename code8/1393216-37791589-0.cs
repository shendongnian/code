    var columns = dt.Columns.Cast<DataColumn>()
                    .Where(x => x.DataType == typeof(bool))
                    .Select(x => new
                    {
                        Column = x,
                        Count = dt.Rows.Cast<DataRow>()
                                    .Count(r => r.Field<bool>(x) == true)
                    }).OrderByDescending(x => x.Count)
                    .Select(x => x.Column).ToList();
    grid.Columns.Cast<DataGridViewColumn>()
        .Where(x => columns.Select(c => c.ColumnName).Contains(x.DataPropertyName))
        .ToList()
        .ForEach(x => grid.Columns.Remove(x));
    columns.ForEach(x =>
    {
        grid.Columns.Add(new DataGridViewCheckBoxColumn()
        {
            DataPropertyName = x.ColumnName,
            HeaderText = x.Caption
        });
    });
