        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using Microsoft.Office.Interop.Excel;
        
        namespace ExcelTest1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    var excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = true;
                    var book = excel.Workbooks.Open(@"D:\test.xlsx");
                    var sheet = book.Sheets[1];
                    var range = sheet.UsedRange;
        
                    //Filter the sheet itself.                
                    range.AutoFilter(Field: 2, Criteria1: "BBB");
                    //and get only visible cells after the filter.
                    var result = range.SpecialCells(XlCellType.xlCellTypeVisible, Type.Missing);
                    Console.WriteLine(result.Rows.Count);
                    foreach (Range row in result.Rows)
                    {
                        Console.WriteLine(row.Cells[1,3].Value2());
                    }
                    book.Close(SaveChanges:false);
                    excel.Quit();
                    Console.ReadLine();
                }
            }
        }
