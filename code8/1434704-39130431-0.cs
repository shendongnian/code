    private static Excel.Workbook MyBook = null;
    private static Excel.Application MyApp = null;
    private static Excel.Worksheet MySheet = null;
    static void ReadExcel()
    {
        MyApp = new Excel.Application();
        MyApp.Visible = false;
        MyBook = MyApp.Workbooks.Open("C:\\test.xlsx");
        MySheet = (Excel.Worksheet)MyBook.Sheets[1];
        if (MySheet.Visible == Excel.XlSheetVisibility.xlSheetHidden)
        {
            //handle hidden sheet here
        }
    }
