     FileInfo[] excelFiles = di.GetFiles("*.xlsx");
     if (excelFiles.Length > 0)
     {
         Dts.Variables["ExcelFilesList"].Value =
             excelFiles.Select(file => new ExcelModel 
                                       {
                                           ExcelFilePath = file.FullName 
                                       })
                       .ToList();
     }
