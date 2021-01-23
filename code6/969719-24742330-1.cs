    // Initialize Excel Application
    Excel.Application excelApp = null;
    excelApp = new Excel.Application();
    excelApp.Visible = false;
    excelApp.DisplayAlerts = false;
    // Get the process. Not as precise as would like, but probably the best we can get from an .ASP call
    Process[] possibleProcesses = Process.GetProcessesByName("Excel");
    excelProc = possibleProcesses[0];
    // Object for optional arguments when creating Excel Workbook
    object optional = System.Reflection.Missing.Value;
    Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath, optional, optional, optional, optional, optional, optional, optional, optional, optional, optional, optional, optional, optional, optional);
    excelWorkbook.CheckCompatibility = false;
    excelWorkbook.DoNotPromptForConvert = true;
   
    // Create array with Custom Properties of workbook
    dynamic properties = excelWorkbook.CustomDocumentProperties;
    // Iterate through each worksheet in the workbook
    foreach (Excel.Worksheet excelWorksheet in excelWorkbook.Worksheets)
    {
        // Checking to see if any cells are being used. If no cells are used, setting ACTUAL used range causes an error.
        if (excelWorksheet.UsedRange.Cells.Count >=1)
        {
            try
            {
                // Because these sheets have thousands of edited (but unused) cells, can't use UsedRange without major performance issue. Getting last used cell manually.
                int lastRow = 1;
                int lastCol = 1;
                try
                {
                    lastRow = excelWorksheet.Cells.Find("*", excelWorksheet.get_Range("IV65536", optional), Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;
                    lastCol = excelWorksheet.Cells.Find("*", excelWorksheet.get_Range("IV65536", optional), Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByColumns, Excel.XlSearchDirection.xlPrevious, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;
                }
                catch { }
                Excel.Range excelRange = excelWorksheet.get_Range(excelWorksheet.Cells[1, 1], excelWorksheet.Cells[lastRow, lastCol]);
                // Creating array of cells in range, because search operations are faster on array than on cells.
                dynamic cells = excelRange.Cells;
                string cellAddress = "";
                string cellFormula = "";
                string formulaParameter = "";
                int parameterLength = 0;
                // Search array for cells that have functions. If a function exists, replace it with the value that should be returned from the function.
                foreach (dynamic c in cells)
                {
                    if (c.HasFormula())
                    {
                        cellFormula = c.formula;
                        cellAddress = c.address.Replace("$", "");
                        if ((cellFormula.Length > 50) && (cellFormula.Substring(0, 50) == "=YOURCUSTOMEXCELFUNCTIONHERE"))
                        {
                            // Get custom functions, replace functions with the values returned from those functions
                            parameterLength = cellFormula.Substring(52).Length;
                            formulaParameter = cellFormula.Substring(52, parameterLength - 2);
                            foreach (dynamic p in properties)
                            {
                                if (p.name == formulaParameter)
                                {
                                    excelWorksheet.get_Range(cellAddress, optional).Value2 = p.Value;
                                }
                            }
                        }
                        else
                        {
                            // Get non-custom functions, replace functions with the values returned from those functions                                                       
                            excelWorksheet.get_Range(cellAddress, optional).Value2 = c.Value2;
                        }
                    }
                }
            }
            catch { }
        }
    }
