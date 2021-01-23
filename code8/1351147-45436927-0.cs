    using (ExcelPackage packageNew = new ExcelPackage())
    {
    ExcelWorksheet worksheetNew = packageNew.Workbook.Worksheets.Add("Sheet1");
    worksheet.Cells["A1"].Value = "what ever";
    .
    .
    .
    Byte[] bin =    package.GetAsByteArray();
                    string file = newFile.FullName; ;
                    File.WriteAllBytes(file, bin);
    
                    //These lines will open it in Excel
                    ProcessStartInfo pi = new ProcessStartInfo(file);
                    Process.Start(pi);
    }
