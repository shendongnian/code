    using (var app = new ExcelPackage())
    {
       var workSheet = app.Workbook.Worksheets.Add("asdf");
       var address = new ExcelAddress("$A:$A");
       var condition = workSheet.ConditionalFormatting.AddExpression(address);
       workSheet.Cells["A1"].Value = "asdfasdfasdfasdfasdfasfdasd";
       condition.Formula = "=IF(LEN(A1)>25, TRUE, FALSE)";
       condition.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
       condition.Style.Fill.BackgroundColor.Color = System.Drawing.Color.Green;
       var destinationPath = @"../../GeneratedExcelFile.xlsx";
       File.WriteAllBytes(destinationPath, app.GetAsByteArray());
    }
