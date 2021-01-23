    DefaultSchema
    .Zip(MyTables,
        (x, y) => new
            { Name = x.Name,
              MissingColumns = x.Columns.Select(x1 => x1.Name)
                  .Except(y.Columns.Select(y1 => y1.Name)) });
