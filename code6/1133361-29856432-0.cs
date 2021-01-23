    using (ExcelPackage package = new ExcelPackage(new FileInfo(@"C:\Temp\example.xlsx")))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.First();
                ws.Cells["A1:A2"].Merge = true;
                package.Save();
            }
