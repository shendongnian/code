    foreach (var column in dbTable.Columns)
    {
        Console.WriteLine(column.DataType);
        Console.WriteLine(column.DefaultValue);
        Console.WriteLine(column.AutoIncrement);
        Console.WriteLine(column.ColumnName);
        Console.WriteLine(column.MaxLength);
        Console.WriteLine(column.Table);
    }
