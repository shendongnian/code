     private static List<DataTable> SplitTable(DataTable mainTable, int batchSize)
    {
        List<DataTable> tables = new List<DataTable>();
        int i = 0;
        int j = 1;
        int rowCount = 0;
        DataTable tempDt = mainTable.Clone();
        tempDt.TableName = "ChunkDataTable" + j.ToString();
        tempDt.Clear();
        foreach (DataRow row in mainTable.Rows) {
            rowCount += 1;
            DataRow newRow = tempDt.NewRow();
            newRow.ItemArray = row.ItemArray;
            tempDt.Rows.Add(newRow);
            i += 1;
            if (i == batchSize | rowCount == mainTable.Rows.Count) {
                tables.Add(tempDt);
                j += 1;
                tempDt = mainTable.Clone();
                tempDt.TableName = "ChunkDataTable" + j.ToString();
                tempDt.Clear();
                i = 0;
            }
        }
        return tables;
    }
