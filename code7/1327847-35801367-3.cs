    /// <summary>
    /// export DataTable to Excel (C#)
    /// </summary>
    internal static void Export2Excel(DataTable dataTable)
    {
        object misValue = System.Reflection.Missing.Value;
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
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                // array of column names
                _arrColumnNames[i] = dataTable.Columns[i].ColumnName;
            }
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
        }
        catch { throw; }
    }
