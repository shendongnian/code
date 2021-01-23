    using System;
    using System.Data.SQLite;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ExcelSqlite
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
    
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    
                string cs = "URI=file:test.db";
                string data = String.Empty;
    
                int i = 0;
                int j = 0;
    
                using (SQLiteConnection con = new SQLiteConnection(cs))
                {
                    con.Open();
    
                    string stm = "SELECT * FROM Contacts";
    
                    using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read()) // Reading Rows
                            {
                                for (j = 0; j <= rdr.FieldCount - 1; j++) // Looping throw colums
                                {
                                    data = rdr.GetValue(j).ToString();
                                    xlWorkSheet.Cells[i + 1, j + 1] = data;
                                }
                                i++;
                            }
                        }
                    }
                    con.Close();
                }
    
                xlWorkBook.SaveAs("sqliteToExcel.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
    
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
    
            private static void releaseObject(object obj)
            {
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                    obj = null;
                }
                catch (Exception ex)
                {
                    obj = null;
                }
                finally
                {
                    GC.Collect();
                }
            }
        }
    }
