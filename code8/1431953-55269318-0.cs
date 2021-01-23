    using Microsoft.Office.Interop.Excel;
    using _Excel = Microsoft.Office.Interop.Excel;
    using System;
    using System.IO;
    namespace ConsoleAppCallVBA
    {
        class Program
        {
        static void Main(string[] args)
        {
           
            string errorMessage = string.
            #region Check is Excel is installed in the PC on which program is executed
            _Application excel = new _Excel.Application();
            if (excel == null)
            {
                
                errorMessage = "EXCEL could not be started." + "\n" +
                    "This program is able to form reports only on PC with installed Excel. " + "\n" +
                    "Check that your office installation is correct.";
                Console.WriteLine(errorMessage);
            }
            #endregion
            excel.Visible = true;
            string fileName = "HelloWorldVBACodeExample.xlsm";
            string pathToExcelXlsmFile = Path.Combine(path, fileName);
            Workbook wb;
            Worksheet ws;
            int sheetNumber = 1;
            wb = excel.Workbooks.Open(pathToExcelXlsmFile);
            ws = wb.Worksheets[sheetNumber];
            //Call VBA code
            excel.GetType().InvokeMember("Run", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod, null, excel, new Object[] { "HelloWorldVBACodeExample.xlsm!HelloWorld", "My Name"});
            #region Close excel object - release memory from this application
            excel.Quit();
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excel);
            #endregion
            }
         }
     }
