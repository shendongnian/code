    var options = SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.CheckConstraints;
    using (var bulkCopy = new SqlBulkCopy(connection, options, transaction))
    {
    	// ...Code...
    }
