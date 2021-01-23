    internal static bool? ExcelContainsMacros(string pathToExcelFile)
    {
        bool? _hasMacro = null;
        Microsoft.Office.Interop.Excel._Application _appExcel = 
            new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook _workbook = null;
        try
        {
            _workbook = _appExcel.Workbooks.Open(pathToExcelFile, 
                                                 System.Reflection.Missing.Value, 
                                                 true);
            _hasMacro = _workbook.HasVBProject;
            _workbook.Close();
            LogHasMacros(hasMacros);
            return _hasMacro;
        }
        catch (Exception ex)
        {
            LogError(ex);
            return null;
        }
        finally { _appExcel.Quit(); }
    }
