    private static void SetWorksheet()
    {
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        xlApp = new Excel.Application();
        xlApp.Visible = true;
        xlWorkBook = xlApp.Workbooks.Add(1);
        string[] storeArray = { "1101", "1102", "1103" };
        foreach (string s in storeArray)
        {
            xlWorkBook.Worksheets.Add(After: xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);
            //xlWorkBook.ActiveSheet(After: xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[xlWorkBook.Sheets.Count];
            xlWorkSheet.Name = s;
            releaseObject(xlWorkSheet);
        }
        releaseObject(xlWorkBook);
        releaseObject(xlApp);  
    }
