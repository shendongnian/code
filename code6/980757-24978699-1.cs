    using Excel = Microsoft.Office.Interop.Excel;
    Excel.Application app= new Excel.Application();
    app.ErrorCheckingOptions.BackgroundChecking = false;//This line disable error checking
    Excel.Workbook wb = app.Workbooks.Open(path, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
    ...
    wb.Close(true, url, null);
