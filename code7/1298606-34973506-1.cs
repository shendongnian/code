    // Get the tables using GetSchema:
    dtbTables = dbConnection.GetSchema("tables");
    
    // use linq to get the table whose name matches the criteria:
    DataRow recSpecificTable = dbConnection.GetSchema("Tables").AsEnumerable()
                    .Where(r => r.Field<string>("TABLE_NAME")
                    .StartsWith("customer")).FirstOrDefault();
    
    // Now the table name I am looking for:
    tableName = Convert.ToString(recSpecificTable["TABLE_NAME"]).Trim();
