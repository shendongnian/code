    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Excel;
    
    namespace MultipleExcelReadWriteExample
    {
        public class Program
        {
            private static void Main(string[] args)
            {
                // create a instance of the file manager
                var fileManager = new FileManager();
    
                // add the list of file paths to collection
                fileManager.ListOfWorkbooksPath.Add("workBookToRead1", @"C:\ExcelFiles\WorkbookToRead1.xlsx");
                fileManager.ListOfWorkbooksPath.Add("workBookToRead2", @"C:\ExcelFiles\WorkbookToRead2.xlsx");
                fileManager.ListOfWorkbooksPath.Add("workBookToRead3", @"C:\ExcelFiles\WorkbookToRead3.xlsx");
                fileManager.ListOfWorkbooksPath.Add("workBookToWrite1", @"C:\ExcelFiles\WorkbookToWrite1.xlsx");
    
                // Open the excel app
                fileManager.OpenExcelApp();
                // open all the workbooks
                fileManager.OpenWorkbooks();
    
                // Do some data transfer here!
                int index = 1;
                foreach (var workbook in fileManager.ListOfWorkbooks)
                {
                    if (workbook.Key.Contains("workBookToRead"))
                    {
                        // get the worksheet to read
                        var readWorksheet = workbook.Value.Worksheets["Sheet1"] as Worksheet;
    
                        // get the writing workbook
                        Workbook workbookToWrite = fileManager.ListOfWorkbooks["workBookToWrite1"];
                        // get the worksheet to write
                        var writeWorksheet = workbookToWrite.Worksheets["Sheet" + index] as Worksheet;
                        //TODO: create a new sheet if doesn't exist
    
                        for (int column = 1; column <= 10; column++)
                        {
                            for (int row = 1; row <= 10; row++)
                            {
                                // read the data from the worksheet
                                Tuple<dynamic, dynamic> data = fileManager.ReadFromCell(readWorksheet, column, row);
    
                                // write the data to the worksheet
                                fileManager.WriteToCell(writeWorksheet, column, row, data);
                            }
                        }
                    }
    
                    index++;
                }
    
                // save all workbooks
                fileManager.SaveAllWorkbooks();
                // close all workbooks
                fileManager.CloseAllWorkbooks();
                // close the excel app
                fileManager.CloseExcelApp();
    
                Console.WriteLine("Press key to continue");
                Console.ReadKey();
            }
        }
    
    
        public class FileManager
        {
            private Application _excelApp;
    
            /// <summary>
            ///     Basic c'tor
            /// </summary>
            public FileManager()
            {
                ListOfWorkbooksPath = new Dictionary<string, string>();
                ListOfWorkbooks = new Dictionary<string, Workbook>();
            }
    
            /// <summary>
            ///     List of workbook to read, with their name and path
            /// </summary>
            public Dictionary<string, string> ListOfWorkbooksPath { get; set; }
    
            public Dictionary<string, Workbook> ListOfWorkbooks { get; set; }
    
            /// <summary>
            ///     Finalizer
            /// </summary>
            ~FileManager()
            {
                if (_excelApp != null)
                {
                    _excelApp.Quit();
                    Marshal.ReleaseComObject(_excelApp);
                }
    
                _excelApp = null;
            }
    
            /// <summary>
            ///     Open the Excel application
            /// </summary>
            public void OpenExcelApp()
            {
                _excelApp = new Application();
            }
    
            /// <summary>
            ///     Open list of workbooks for given path
            /// </summary>
            public void OpenWorkbooks()
            {
                foreach (var item in ListOfWorkbooksPath)
                {
                    if (!ListOfWorkbooks.ContainsKey(item.Key))
                    {
                        Workbook workbook = _excelApp.Workbooks.Open(item.Value);
                        ListOfWorkbooks.Add(item.Key, workbook);
                    }
                }
            }
    
            /// <summary>
            ///     Read a cell and return the value and the cell format
            /// </summary>
            /// <param name="worksheet">The worksheet to read the value from.</param>
            /// <param name="column">The column number to read the value from.</param>
            /// <param name="row">The row number to read the value from.</param>
            /// <returns>The value and cell format.</returns>
            public Tuple<dynamic, dynamic> ReadFromCell(Worksheet worksheet, int column, int row)
            {
                var range = worksheet.Cells[row, column] as Range;
    
                if (range != null)
                {
                    dynamic value = range.Value2; // get the value of the cell
                    dynamic format = range.NumberFormat; // get the format of the cell
                    return new Tuple<dynamic, dynamic>(value, format);
                }
    
                return null;
            }
    
            /// <summary>
            ///     Write the data to a cell in worksheet.
            /// </summary>
            /// <param name="worksheet">The worksheet to write the value.</param>
            /// <param name="column">The column number to write the value.</param>
            /// <param name="row">The row number to write the value.</param>
            /// <param name="data">The data to be written to a cell; this is a Tuple that contains the value and the cell format.</param>
            public void WriteToCell(Worksheet worksheet, int column, int row, Tuple<dynamic, dynamic> data)
            {
                var range = worksheet.Cells[row, column] as Range;
    
                if (range != null)
                {
                    range.NumberFormat = data.Item2; // set the format of the cell
                    range.Value2 = data.Item1; // set the value of the cell
                }
            }
    
    
            /// <summary>
            ///     Save all workbooks
            /// </summary>
            public void SaveAllWorkbooks()
            {
                foreach (var workbook in ListOfWorkbooks)
                {
                    SaveWorkbook(workbook.Value);
                }
            }
    
            /// <summary>
            ///     Save single workbook
            /// </summary>
            /// <param name="workbook"></param>
            public void SaveWorkbook(Workbook workbook)
            {
                workbook.Save();
            }
    
            /// <summary>
            ///     Close all workbooks
            /// </summary>
            public void CloseAllWorkbooks()
            {
                foreach (var workbook in ListOfWorkbooks)
                {
                    CloseWorkbook(workbook.Value);
                }
    
                ListOfWorkbooks.Clear();
            }
    
            /// <summary>
            ///     Close single workbook
            /// </summary>
            /// <param name="workbook"></param>
            public void CloseWorkbook(Workbook workbook)
            {
                workbook.Close();
            }
    
            /// <summary>
            ///     Close the Excel Application
            /// </summary>
            public void CloseExcelApp()
            {
                if (_excelApp != null)
                {
                    _excelApp.Quit();
                }
    
                _excelApp = null;
                ListOfWorkbooksPath.Clear();
            }
        }
    }
