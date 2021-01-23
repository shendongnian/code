    foreach (DataRow row in dr)
    {
       for (col = 0; col < dtMainSQLData.Columns.Count; col++)
       {
          string outputData = row[col].ToString().Replace("&lt;", "<");
          outputData = outputData.Replace("&gt;", ">");
          rowData[rowCnt, col] = outputData;
       }
       rowCnt++;
    }
