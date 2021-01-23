    List<Engagement> QueryResult = PMService.GetRequestedEngagments(test);
                    
            var filename = yourfilename;
            var path = @"C:\Users\er4505\Downloads" + filename;
            var excelFileInfo = new FileInfo(path);         
            try
            {
                using (ExcelPackage csvToExcel = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = csvToExcel.Workbook.Worksheets.Add(filename);
                    worksheet.Cells["A1"].LoadFromCollection(QueryResult, true, OfficeOpenXml.Table.TableStyles.Medium25);
                    csvToExcel.SaveAs(excelFileInfo);
                }
            }
