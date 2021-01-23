    using System;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace WindowsFormsApplication1_CS
    {
        public class ExcelCode
        {
            public System.Drawing.Color ForeColor;
            public ExcelCode() { }
    
            public string GetCellValue(
                string FileName,
                string SheetName,
                string CellAddress)
            {
                string CellValue = "";
    
                if (System.IO.File.Exists(FileName))
                {
                    bool Proceed = false;
    
                    Excel.Application xlApp = null;
                    Excel.Workbooks xlWorkBooks = null;
                    Excel.Workbook xlWorkBook = null;
                    Excel.Worksheet xlWorkSheet = null;
                    Excel.Sheets xlWorkSheets = null;
                    Excel.Range xlCells = null;
    
                    xlApp = new Excel.Application();
                    xlApp.DisplayAlerts = false;
                    xlWorkBooks = xlApp.Workbooks;
                    xlWorkBook = xlWorkBooks.Open(FileName);
    
                    xlApp.Visible = false;
    
                    xlWorkSheets = xlWorkBook.Sheets;
    
                    for (int x = 1; x <= xlWorkSheets.Count; x++)
                    {
                        xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];
    
                        if (xlWorkSheet.Name == SheetName)
                        {
                            Proceed = true;
                            break;
                        }
    
                        System.Runtime.InteropServices
                            .Marshal.FinalReleaseComObject(xlWorkSheet);
    
                        xlWorkSheet = null;
    
                    }
    
                    if (Proceed)
                    {
                        xlCells = xlWorkSheet.Range[CellAddress];
    
                        try
                        {
                            Console.WriteLine("Bold: {0}", xlCells.Font.Bold);   //  bool
                            Console.WriteLine("Italic: {0}", xlCells.Font.Italic); // bool
                            ForeColor = System.Drawing.ColorTranslator.FromOle((int)xlCells.Font.Color);
                            CellValue = Convert.ToString(xlCells.Value);
                        }
                        catch (Exception)
                        {
                            // Reduntant
                            CellValue = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show(SheetName + " not found.");
                    }
    
                    xlWorkBook.Close();
                    xlApp.UserControl = true;
                    xlApp.Quit();
    
                    ReleaseComObject(xlCells);
                    ReleaseComObject(xlWorkSheets);
                    ReleaseComObject(xlWorkSheet);
                    ReleaseComObject(xlWorkBook);
                    ReleaseComObject(xlWorkBooks);
                    ReleaseComObject(xlApp);
                }
                else
                {
                    MessageBox.Show("'" + FileName +
                        "' not located. Try one of the write examples first.");
                }
    
                return CellValue;
            }
    
            public static void ReleaseComObject(object obj)
            {
                try
                {
                    if (obj != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                        obj = null;
                    }
                }
                catch (Exception)
                {
                    obj = null;
                }
            }
        }
    }
