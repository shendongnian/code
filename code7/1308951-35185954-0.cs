    private void SaveDataArray(string excelFileName, string[,] dataArray)
    {
      var xlApp = new Application();
      var xlWorkBook = xlApp.Workbooks.Add();
      var xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.Item[1];
      for (int i = 0; i < dataArray.GetLength(0); i++)
      {
        for (int j = 0; j < dataArray.GetLength(1); j++)
        {
          xlWorkSheet.Cells[j + 1, i + 1] = dataArray[i, j];
        }
      }
      
      xlWorkBook.SaveAs(excelFileName);
      xlWorkBook.Close(true);
      xlApp.Quit();
    }
