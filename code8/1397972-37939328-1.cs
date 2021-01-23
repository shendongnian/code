    [HttpPost] 
    public ActionResult Upload(WhateverModel model)
    { 
        fileName = file.FileName;  
        var dataList = new List<ExcelDataModel>();
        using (var package = new ExcelPackage(file.InputStream))
        {
            var currentSheet = package.Workbook.Worksheets;
            var workSheet = currentSheet.First();
            var rowCount = workSheet.Dimension.End.Row;
    
            for (int i = 2; i <= rowCount; i++)
            {
                var dm = new ExcelDataModel
                {
                    Value = workSheet.Cells[i, 1].Value.ToString(),
                    Name = workSheet.Cells[i, 2].Value.ToString(),
                    Label = workSheet.Cells[i, 3].Value.ToString()
                };
    
                dataList.Add(dm);
            }
         }
    }
