    String[,] arr = new String[xlWorksheet.UsedRange.Rows.Count,xlWorksheet.UsedRange.Columns.Count];
    for (int row = 1; row <= xlWorksheet.UsedRange.Rows.Count; ++row)
    {
          for (int col = 1; col <= xlWorksheet.UsedRange.Columns.Count; ++col)
          {
            arr[row,col] = valueArray[row, col].ToString();
          } 
    }
