    Excel.Workbook wb;
    try
    {
      wb = excelApp.Workbooks[System.IO.Path.GetFileName(myPath)];
    }
    catch
    {
      wb = excelApp.Workbooks.Open(myPath);
    }
