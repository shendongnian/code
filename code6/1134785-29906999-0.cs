            using (var excelPackage = new ExcelPackage())
            {
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("Data");
                ws.Cells["A1"].Value = "Tel. No as number:";
                ws.Cells["B1"].Value = 1231231234;
                ws.Cells["A2"].Value = "Tel. No as text:";
                ws.Cells["B2"].Value = "1231231234";
                ws.Column(1).AutoFit();
                ws.Column(2).AutoFit();
                excelPackage.SaveAs(new FileInfo(@"C:\Temp\OutputExample.xlsx"));
            }
