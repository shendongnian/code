    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Excel = Microsoft.Office.Interop.Excel;
    namespace OpenExcel {
    class Program {
        static void Main(string[] args) {
            Excel.Application xlApp = null;
            try {
                xlApp = new Excel.Application();
                xlApp.Visible = true;
                Excel.Workbook xlWb = xlApp.Workbooks.Open(@"C:\Users\joe.bob\Desktop\tmp\Book1.xlsx"); //include the path to your real Excel file
                Excel.Worksheet xlWSht = xlWb.Sheets["Sheet1"]; //include the name of your worksheet where you have the data
                //here the data is on a Worksheet called Sheet1
                int startRow = 9; //this is the row where the data starts
                string startCol = "A"; //the start column
                int endRow = 15;
                string endCol = "F";
                int filterColumn = 6; //this is an OFFSET
                string[] filterList = new string[] { "DTP-3432", "DTP-343243" }; //this is the list of values you want to show
                Excel.Range myData = xlWSht.get_Range(startCol + startRow, endCol + endRow);
                myData.AutoFilter(filterColumn, filterList.Length > 0 ? filterList : Type.Missing, Excel.XlAutoFilterOperator.xlFilterValues, Type.Missing, true);
                Console.WriteLine("Press a key to quit...");
                Console.ReadKey();
            }
            finally {
                if (xlApp != null) {
                    xlApp.Quit();
                }
            }
        } //end main
    } //end program
    } //end namespace
