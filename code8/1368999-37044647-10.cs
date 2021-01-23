    private DataTable TransposeTable(DataTable inputTable)
    {
        DataTable outputTable = new DataTable();
           
        for (int i = 0; i < inputTable.Rows.Count; i++)
        {
            outputTable.Columns.Add("col" + i);
        }
        for (int rCount = 0; rCount <= inputTable.Columns.Count - 1; rCount++)
        {
            DataRow newRow = outputTable.NewRow();
            newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
            for (int cCount = 0; cCount <= inputTable.Rows.Count - 2; cCount++)
            {
                string colValue = inputTable.Rows[cCount][rCount].ToString();
                newRow[cCount + 1] = colValue;
            }
            outputTable.Rows.Add(newRow);
        }
        return outputTable;
    }
