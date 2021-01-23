    var allSubTables = new List<DataTable>();
    string[] relevantColumns = { "Mac", "Win", "zo", "dz", "dx", "zx", };
    DataTable lookUpTable = new DataTable();
    foreach (string colName in relevantColumns)
        lookUpTable.Columns.Add(colName);
    foreach (string t in LookUpDir)
    {
        LookUpFile = t;
        if (LookUpFile.Contains("Brand"))
        {
            DataTable textFileTable = ConvertTextFileToDataTable(LookUpFile);
            DataTable subTable = lookUpTable.Clone(); // same columns, empty
            foreach (DataRow row in textFileTable.Rows)
            {
                DataRow addedRow = subTable.Rows.Add(); // already added now
                foreach (DataColumn col in subTable.Columns)
                    addedRow.SetField(col.ColumnName, row.Field<string>(col.ColumnName));
            }
            allSubTables.Add(subTable);
        }
        else
        {
            Console.WriteLine("\n ... stuck");
            Environment.Exit(-1);
        }
    }
