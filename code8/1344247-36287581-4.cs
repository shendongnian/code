    internal static bool? ExcelContainsMacros(string pathToExcelFile)
    {
        bool? _hasMacro = null;
        Microsoft.Office.Interop.Excel._Application _appExcel = 
            new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook _workbook = null;
        try
        {
            _workbook = _appExcel.Workbooks.Open(pathToExcelFile, Type.Missing, true);
            _hasMacro = _workbook.HasVBProject;
    
            // close Excel workbook and quit Excel app
            _workbook.Close(false, Type.Missing, Type.Missing);
            _appExcel.Application.Quit(); // optional
            _appExcel.Quit();
    
            // release COM object from memory
             System.Runtime.InteropServices.Marshal.FinalReleaseComObject(_appExcel);
            _appExcel = null;
            
            // optional: this Log function should be defined somewhere in your code         
            LogHasMacros(hasMacros);
            return _hasMacro;
        }
        catch (Exception ex)
        {
            // optional: this Log function should be defined somewhere in your code         
            LogError(ex);
            return null;
        }
        finally 
        {
            if (_appExcel != null)
            {
                _appExcel.Quit();
                // release COM object from memory
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(_appExcel);
            }
        }
