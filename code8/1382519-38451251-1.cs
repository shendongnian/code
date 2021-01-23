        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using Excel = Microsoft.Office.Interop.Excel;
        namespace WriteExcelData
        {
        class Program
        {
        static void Main(string[] args)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            List MyInfo = new List { "CLASS NAME", "RESULT", "ReadExcelData", "Success", "WriteExcelData", "Success" };
            int index = 0;
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    xlWorkSheet.Cells[i, j] = MyInfo[index];
                    index++;
                }
            }
            var fileLocation = "C:\\Users\\user\\Desktop\\Selenium       Learing\\WriteExcelData\\TestResultFile\\MyExcelFile.xls";
            xlWorkBook.SaveAs(fileLocation, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
        }
    }
}
