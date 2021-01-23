            var sbCopy = new SqlBulkCopy("myConnectionString")
            {
                DestinationTableName = tableName,
                BatchSize = 100000
            };
            sbCopy.WriteToServer(_log_data.AsDataReader());
