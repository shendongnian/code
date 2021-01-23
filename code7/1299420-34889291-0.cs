    var result =
        DefaultSchema
            .Select(
                table =>
                    new
                    {
                        Table = table,
                        UserTable = MyTables.FirstOrDefault(utable => utable.Name == table.Name)
                    })
            .Select(item => new
            {
                Name = item.Table.Name,
                MissingColumns =
                    item.UserTable == null
                        ? item.Table.Columns.Select(x => x.Name).ToArray()
                        : item.Table.Columns.Select(x => x.Name)
                            .Except(item.UserTable.Columns.Select(x => x.Name))
                            .ToArray()
            }).ToList();
