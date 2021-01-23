    List<TheOldType> list
    var data = Convert(list);
    using(var bcp = new SqlBulkCopy(connection))
    using(var reader = ObjectReader.Create(data, "ColumnName"))
    {
        bcp.DestinationTableName = "SomeTable";
        bcp.WriteToServer(reader);
    }
