    using System;
    using System.Reflection;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ConsoleApplication13
    {
        class ExcelWorker : IDisposable
        {
            private Excel.Application _excelApp;
    
            private Excel.Workbook _workbook;
            private Excel.Worksheet _mainWorksheet;
    
            private readonly string _workbookPath;
    
            public ExcelWorker(string workbookPath)
            {
                _workbookPath = workbookPath;
            }
    
            public void Start()
            {
                _excelApp = new Excel.Application();
    
                _excelApp.Visible = true;
                
                var workbooks = _excelApp.Workbooks;
    
                _workbook = workbooks.Open(_workbookPath,
                    0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                    true, false, 0, true, false, false);
                
                var workheets = _workbook.Worksheets;
    
                _mainWorksheet = (Excel.Worksheet) workheets.Item[1];
            }
    
            public void DoStuff()
            {
                var cell = (Excel.Range)_mainWorksheet.Cells[4, "U"];
                
                cell.set_Value(Missing.Value, 99);
            }
    
            public void Stop()
            {
                if (_workbook != null)
                {
                    _workbook.Close(false, Missing.Value, Missing.Value);
    
                    _workbook = null;
                    _mainWorksheet = null;
                }
    
                if (_excelApp != null)
                {
                    _excelApp.Quit();
    
                    _excelApp = null;
                }
    
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
    
            public void Dispose()
            {
                Stop();
            }
        }
    
        class Program
        {
    
            static void Main(string[] args)
            {
                using (var excelWorker = new ExcelWorker(@"C:\.....xlsx"))
                {
                    excelWorker.Start();
    
                    excelWorker.DoStuff();
    
                    excelWorker.DoStuff();
                }
    
                Console.ReadKey();
            }
        }
    }
