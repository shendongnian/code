    using (SqlBulkCopy bcp = new SqlBulkCopy(YourConnectionString))
                {
                    // +1 to Marc Gravell for this neat little library to do the mapping for us
                    // because DataTable isn't available until .NET Standard Library 2.0
                    using (var dataReader = ObjectReader.Create(yourListOfObjects,
                        nameof(YourClass.Property1),
                        nameof(YourClass.Property2)))
                    {
                        bcp.DestinationTableName = "YourTableNameInSQL";
                        bcp.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Property1", "MyCorrespondingTableColumn"));
                        bcp.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Property2", "TableProperty2"));
                        
                       
                        await bcp.WriteToServerAsync(dataReader).ConfigureAwait(false);
                    }
                }
