     internal static bool Export2Excel(DataTable dataTable, bool Interactive)
        {
            object misValue = System.Reflection.Missing.Value;
    
            // Note: don't put Microsoft.Office.Interop.Excel in 'using' section:
            // it may cause ambiguity w/System.Data because both have DataTable obj
            // use in-place reference as shown below
            Microsoft.Office.Interop.Excel.Application _appExcel = null;
            Microsoft.Office.Interop.Excel.Workbook _excelWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet _excelWorksheet = null;
            try
            {
                // excel app object
                _appExcel = new Microsoft.Office.Interop.Excel.Application();
                
                // excel workbook object added to app
                _excelWorkbook = _appExcel.Workbooks.Add(misValue);
    
                _excelWorksheet = _appExcel.ActiveWorkbook.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
    
                // column names row (range obj)
                Microsoft.Office.Interop.Excel.Range _columnsNameRange;
                _columnsNameRange = _excelWorksheet.get_Range("A1", misValue).get_Resize(1, dataTable.Columns.Count);
    
                // column names array to be assigned to _columnNameRange
                string[] _arrColumnNames = new string[dataTable.Columns.Count];
              
                // assign array to column headers range, make 'em bold
                _columnsNameRange.set_Value(misValue, _arrColumnNames);
                _columnsNameRange.Font.Bold = true;
    
                // populate data content row by row
                for (int Idx = 0; Idx < dataTable.Rows.Count; Idx++)
                {
                    _excelWorksheet.Range["A2"].Offset[Idx].Resize[1, dataTable.Columns.Count].Value =
                    dataTable.Rows[Idx].ItemArray;
                }
    
                // Autofit all Columns in the range
                _columnsNameRange.Columns.EntireColumn.AutoFit();
                
    
                // make visible and bring to the front (note: warning due to .Activate() ambiguity)
                if (Interactive)  { _appExcel.Visible = Interactive; _excelWorkbook.Activate(); }
                // // save and close if Interactive flag not set
                else
                {
                    // Excel 2010 - "14.0"
                    // Excel 2007 - "12.0"
                    string _ver = _appExcel.Version;
                    double _dblVer = double.Parse(_ver);
    
                    string _fileName ="TableExported_" + 
                        DateTime.Today.ToString("yyyy_MM_dd") + "-" +
                        DateTime.Now.ToString("hh_mm_ss");
    
                    // check version and select file extension
                    if (_dblVer >= 12) { _fileName += ".xlsx"; }
                    else { _fileName += ".xls"; }
    
                    // save and close Excel workbook in Document Dir
                    string _subDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _expDir);
    
                    // create if target directory doesn't exists
                    if (!System.IO.Directory.Exists(_subDir)) { System.IO.Directory.CreateDirectory(_subDir); }
    
                    // format the full File path
                    string _pathFile = System.IO.Path.Combine(_subDir, _fileName);
    
                    // save file and close Excel workbook
                    _excelWorkbook.Close(true, _pathFile, misValue);
                }
    
                // quit excel app process
                if (_appExcel != null)
                {
                    _appExcel.UserControl = false;
                    _appExcel.Quit();
                }
                return true;
            }
            catch (Exception ex) 
             {  
                // alternatively you can show Error message
                throw; 
              }
            finally
            {
                // release ref vars
                if (_appExcel != null)
                {
                    _excelWorksheet = null;
                    _excelWorkbook = null;
                    _appExcel = null;
                    misValue = null;
                }
            }
        }
