    using System;
    using Microsoft.Office.Interop.Excel;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Go");
                var t = ReadFile(@"<filename>", "<sheetname>");
                Console.WriteLine("1");
                Console.ReadLine();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                Console.ReadLine();
            }
    
    
            public static object[,] ReadFile(string filepath, string sheetname)
            {
                Application xlApp = null;
                Workbooks wks = null;
                Workbook wb = null;
                object[,] values = null;
                try
                {
                    xlApp = new Application();
                    wks = xlApp.Workbooks;
                    wb = wks.Open(filepath);
                    Worksheet sh = (Worksheet)wb.Worksheets.get_Item(sheetname);
    
                    values = sh.UsedRange.Value2 as object[,];
    
                    //System.Runtime.InteropServices.Marshal.FinalReleaseComObject(sh);
                    //sh = null;
    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(string.Format("Sheet \"{0}\" does not exist in the Excel file", sheetname));
                }
                finally
                {
    
                    if (wb != null)
                    {
    
                        wb.Close(false);
                        //Marshal.FinalReleaseComObject(wb);
                        wb = null;
                    }
    
                    if (wks != null)
                    {
                        wks.Close();
                        //Marshal.FinalReleaseComObject(wks);
                        wks = null;
                    }
    
                    if (xlApp != null)
                    {
                        // Close Excel.
                        xlApp.Quit();
                        //Marshal.FinalReleaseComObject(xlApp);
                        xlApp = null;
                    }
    
    
                }
    
                return values;
            }
        }
    
    }
