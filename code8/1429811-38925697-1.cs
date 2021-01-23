    DataColumn idColumn = new DataColumn("ID");
    DataColumn nameColumn = new DataColumn("Name");
    //nameColumn.Unique = true; //SqlBulkCopy does not care about these settings.
    //nameColumn.AllowDBNull = false;
    DataColumn bulkInsertIDColumn = new DataColumn("BulkInsertID");
    //bulkInsertIDColumn.Unique = false;
    //bulkInsertIDColumn.AllowDBNull = true;
    table.Columns.Add(ID);
    table.Columns.Add(nameColumn);
    table.Columns.Add(bulkInsertIDColumn);
    foreach (string productName in productNames)
    {
        DataRow row = table.NewRow();
        //We don't do anything with row[idColumn]
        row[nameColumn] = productName;
        row[bulkInsertIDColumn] = bulkInsertID;
        table.Rows.Add(row);
    }
