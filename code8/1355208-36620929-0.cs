    string constring = @"Data Source=databasename;Initial Catalog=Rookies;Integrated Security=True";
    
    using (var bulkCopy = new SqlBulkCopy(constring ))
    {
          bulkCopy.BatchSize = 500;
          bulkCopy.NotifyAfter = 1000;
          bulkCopy.DestinationTableName = "TableName";
          bulkCopy.WriteToServer(dataTable);
     }
