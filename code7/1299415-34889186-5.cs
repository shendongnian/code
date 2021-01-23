    DefaultSchema.Zip(MyTables, (x, y) => new
    {
        Name = x.Name,
        MissingColumns = x.Columns.Except(y.Columns, new ColumnComparer())
    });
