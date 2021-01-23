    private void BulkInsert(Type type, string tableName, SqlConnection conn, SqlTransaction tran)
    {
        var props = TypeDescriptor.GetProperties(type)
                        .Cast<PropertyDescriptor>()
                        .ToArray();
    }
