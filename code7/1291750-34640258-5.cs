    private void InitializeExcelObjects()
    {
        _xlApp = new Excel.Application
        {
            SheetsInNewWorkbook = 2,
            StandardFont = "Tahoma",
            StandardFontSize = 11
        };
    
        _xlBook = _xlApp.Workbooks.Add(Type.Missing);
        _xlApp.Windows.Application.ActiveWindow.DisplayGridlines = false;
    
        _xlSheets = _xlBook.Worksheets;
        _xlSheet = (Excel.Worksheet)_xlSheets.Item[1];
        _xlSheetDelPerf = (Excel.Worksheet)_xlSheets.Item[2];
    }
    
    private void DeinitializeExcelObjects()
    {
        Marshal.ReleaseComObject(_xlSheet);
        Marshal.ReleaseComObject(_xlSheetDelPerf);
    
        Marshal.ReleaseComObject(_xlSheets);
    
        _xlBook.Close(false, null, null); 
        Marshal.ReleaseComObject(_xlBook);
    
        _xlApp.DisplayAlerts = false;
        _xlApp.Quit();
        Marshal.ReleaseComObject(_xlApp);
        _xlApp = null;
    }
