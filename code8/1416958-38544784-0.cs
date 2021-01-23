    private List<List<string>> ReadExcelFile(string fileName)
        {
            Excel.Application xlApp = null;
            Workbook xlWorkbook = null;
            Sheets xlSheets = null;
            Worksheet xlSheet = null;
            var results = new List<List<string>>();
            try
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(fileName, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, true, XlPlatform.xlWindows, Type.Missing,false, false, Type.Missing, false, Type.Missing, Type.Missing);
                xlSheets = xlWorkbook.Sheets as Sheets;
                xlSheet = xlSheets[1];
                // Let's say your range is from A1 to DG5200
                var cells = xlSheet.get_Range("A1", "DG5200");
                results = ExcelRangeToListsParallel(cells); 
            }
            catch (Exception)
            {
                results = null;
            }
            finally
            {
                xlWorkbook.Close(false);
                xlApp.Quit();
                if (xlSheet != null)
                    Marshal.ReleaseComObject(xlSheet);
                if (xlSheets != null)
                    Marshal.ReleaseComObject(xlSheets);
                if (xlWorkbook != null)
                    Marshal.ReleaseComObject(xlWorkbook);
                if (xlApp != null)
                    Marshal.ReleaseComObject(xlApp);
                xlApp = null;                
            }
            return results;
        }
        private List<List<String>> ExcelRangeToListsParallel(Excel.Range cells)
        {            
            return cells.Rows.Cast<Excel.Range>().AsParallel().Select(row =>
            {         
                return row.Cells.Cast<Excel.Range>().Select(cell =>
                {
                    var cellContent = cell.Value2;                    
                    return (cellContent == null) ? String.Empty : cellContent.ToString(); 
                }).Cast<string>().ToList();                
            }).ToList();
        }
