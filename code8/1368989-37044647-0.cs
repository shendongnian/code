    private DataTable GenerateTransposedTable(DataTable inputTable)
    {
        DataTable outputTable = new DataTable();
        outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());
        foreach (DataRow inRow in inputTable.Rows)
        {
            string newColName = inRow[0].ToString();
            outputTable.Columns.Add(newColName);
        }
        for (int rCount = 0; rCount <= inputTable.Columns.Count - 1; rCount++)
        {
            DataRow newRow = outputTable.NewRow();
            newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
            for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
            {
                string colValue = inputTable.Rows[cCount][rCount].ToString();
                newRow[cCount + 1] = colValue;
            }
            outputTable.Rows.Add(newRow);
        }
        return outputTable;
    }
