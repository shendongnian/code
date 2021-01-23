    var data = ... // some List<Foo> where Foo has Id, Name and Description
    using(var bcp = new SqlBulkCopy(connection)) // SqlBulkCopy
    using(var reader = ObjectReader.Create(data, "Id", "Name", "Description")) // FastMember
    {
        // these bits are part of the SqlBulkCopy API; WriteToServer accepts *either* a
        // DataTable or an IDataReader; we're providing the latter via FastMember
        bcp.DestinationTableName = "SomeTable";
        bcp.WriteToServer(reader);
    }
