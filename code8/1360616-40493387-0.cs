    DbContext Db = /* ... */;
    var glimpseDbConnection = Db.Database.Connection as GlimpseDbConnection;
    var sqlConnection = glimpseDbConnection != null ? (SqlConnection)glimpseDbConnection.InnerConnection : (SqlConnection)Db.Database.Connection;
    var glimpseDbTransaction = Db.Database.CurrentTransaction.UnderlyingTransaction as GlimpseDbTransaction;
    var sqlTransaction = glimpseDbTransaction != null ? (SqlTransaction)glimpseDbTransaction.InnerTransaction : (SqlTransaction)Db.Database.CurrentTransaction.UnderlyingTransaction;
    using (var bulkCopy = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.Default, sqlTransaction))
    {
        var dataTable = /* ... */;
        bulkCopy.BatchSize = 2000;
        bulkCopy.BulkCopyTimeout = TimeSpan.FromMinutes(5).Seconds;
        bulkCopy.DestinationTableName = /* ... */;
        bulkCopy.WriteToServer(dataTable);
    }
