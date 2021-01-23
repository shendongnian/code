    object[,] objectArray = new object[dtReportData.Rows.Count,
                                       dataTable1.Columns.Count];
    
    for(int row = 0; row < dtReportData.Rows.Count; row++)
    {
      for(int col = 0; col < dtReportData.Columns.Count; col++)
      {
        objectArray[row, col] = dtReportData.Rows[row][col];
      }
    }
