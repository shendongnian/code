      using (var bcp = new SqlBulkCopy(SQLConnectionString))
      using (var reader = ObjectReader.Create(listOfObject))
      {
          bcp.DestinationTableName = "[dbo].[tablename]";
          bcp.ColumnMappings.Add("property1", "tableCol1");
          bcp.ColumnMappings.Add("property2", "tableCol2");
          bcp.ColumnMappings.Add("property3", "tableCol3");
          bcp.WriteToServer(reader);
      }
