    private static void WriteExcelFile(string path)
    {
        using (var package = new ExcelPackage())
        {
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.Add("Sheet1");
            var cell = worksheet.Cells["A1"];
            cell.Value = 20150602125320;
            cell.Style.Numberformat.Format = "0.00";
            
            //DefaultColWidth just set so you don't end up with #######
            //this is not required
            worksheet.DefaultColWidth = 20;
            package.SaveAs(new System.IO.FileInfo(path));
        }
    }
