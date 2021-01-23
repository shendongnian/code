    string FileName = @"D:\Spreadsheet Assignment v2.xlsm"; 
    MyApp = new Excel.Application();
    MyApp.Visible = false;
    MyBook = MyApp.Workbooks.Open(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    sheets = new List<excelsheet>();
    for (int z = 1; z < MyBook.Sheets.Count + 1; z++)
    {
        MySheet = (Excel.Worksheet)MyBook.Sheets[z];
        Excel.Range excelRange = MySheet.UsedRange;
        object[,] valueArray = (object[,])excelRange.get_ValueExcel.XlRangeValueDataType.xlRangeValueDefault);
    }
