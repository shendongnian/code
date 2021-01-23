    using System;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;
    using System.IO;
    
    namespace Example 
    {
        public class ExcelUsed
        {
            /// <summary>
            /// Get last used column for a row
            /// </summary>
            /// <param name="fileName">Excel file to read</param>
            /// <param name="sheetName">Sheet to work on</param>
            /// <param name="row">Row in sheet to get last used column</param>
            /// <returns></returns>
            public int LastColumnForRow(string fileName, string sheetName, int row)
            {
                int lastColumn = -1;
    
                if (File.Exists(fileName))
                {
                    Excel.Application xlApp = null;
                    Excel.Workbooks xlWorkBooks = null;
                    Excel.Workbook xlWorkBook = null;
                    Excel.Worksheet xlWorkSheet = null;
                    Excel.Sheets xlWorkSheets = null;
    
                    xlApp = new Excel.Application();
                    xlApp.DisplayAlerts = false;
    
                    xlWorkBooks = xlApp.Workbooks;
                    xlWorkBook = xlWorkBooks.Open(fileName);
    
                    xlApp.Visible = false;
    
                    xlWorkSheets = xlWorkBook.Sheets;
    
                    for (int x = 1; x <= xlWorkSheets.Count; x++)
                    {
                        xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];
                        
    
                        if (xlWorkSheet.Name == sheetName)
                        {
                            Excel.Range xlCells = null;
                            xlCells = xlWorkSheet.Cells;
    
                            Excel.Range workRange = xlCells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
                            Excel.Range xlColumns = xlWorkSheet.Columns;
    
                            int count = xlColumns.Count;
    
                            Marshal.FinalReleaseComObject(xlColumns);
                            xlColumns = null;
    
                            Excel.Range xlLastRange = (Excel.Range)xlWorkSheet.Cells[row, count];
                            Excel.Range xlDirRange = xlLastRange.End[Excel.XlDirection.xlToLeft];
    
                            Marshal.FinalReleaseComObject(xlLastRange);
                            xlLastRange = null;
    
                            lastColumn = xlDirRange.Column;
                            Marshal.FinalReleaseComObject(xlDirRange);
                            xlDirRange = null;
    
                            Marshal.FinalReleaseComObject(workRange);
                            workRange = null;
    
                            Marshal.FinalReleaseComObject(xlCells);
                            xlCells = null;
    
                            break;
                        }
    
                        Marshal.FinalReleaseComObject(xlWorkSheet);
                        xlWorkSheet = null;
    
                    }
    
                    xlWorkBook.Close();
                    xlApp.UserControl = true;
                    xlApp.Quit();
    
                    Release(xlWorkSheets);
                    Release(xlWorkSheet);
                    Release(xlWorkBook);
                    Release(xlWorkBooks);
                    Release(xlApp);
    
                    return lastColumn;
    
                }
                else
                {
                    throw new Exception("'" + fileName + "' not found.");
                }
            }
             /// <summary>
            /// 
            /// </summary>
            public void CallGarbageCollector()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            /// <summary>
            /// Method to release object used in Excel operations
            /// </summary>
            /// <param name="sender"></param>
            private void Release(object sender)
            {
                try
                {
                    if (sender != null)
                    {
                        Marshal.ReleaseComObject(sender);
                        sender = null;
                    }
                }
                catch (Exception)
                {
                    sender = null;
                }
            }
        }
    }
