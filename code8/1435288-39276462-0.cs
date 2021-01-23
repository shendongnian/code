    using System.Linq;
    using OfficeOpenXml;
    using OfficeOpenXml.Drawing;
    
    namespace EPPlus {
                   public void Run() {
                var excelFile = new System.IO.FileInfo(System.IO.Path.Combine(BaseDirectory, "Excel", "Checkbox.xlsx"));
                using (ExcelPackage excel = new ExcelPackage(excelFile))
                {
                    ExcelWorksheet sheet = excel.Workbook.Worksheets.SingleOrDefault(a => a.Name == "Sheet1");
                    ExcelDrawing checkbox2 = sheet.Drawings.SingleOrDefault(a => a.Name == "Check Box 2");
                   var value = sheet.Cells["G5"].Value.ToString();
    
                }
            }
        }
    }
