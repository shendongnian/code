    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication9
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add("MySheet");
    
                    ws.Cells["A1"].Value = "Some Bold Text";
                    ws.Cells["A1"].Style.Font.Bold = true;
                    ws.Cells["A2"].Value = "Some blue text";
                    ws.Cells["A2"].Style.Font.Color.SetColor(Color.Blue);
                    ws.Cells["A3"].Value = "Some Large Text";
                    ws.Cells["A3"].Style.Font.Size = 22;
    
                    ws.Cells["A3"].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Red);
    
                    ws.Row(3).Height = 23;
                    ws.Column(1).AutoFit();
    
                    package.SaveAs(new System.IO.FileInfo(@"C:\Temp\example.xlsx"));
                }
            }
        }
    }
