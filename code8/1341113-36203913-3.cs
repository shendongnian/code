    FileInfo[] excelFiles = di.GetFiles("*.xlsx");
            ExcelModel model = new ExcelModel();
            if (excelFiles.Length > 0)
            {
                foreach(var item in excelFiles)
                {
                    model = new ExcelModel();
                    model.ExcelFilePath = item.FullName;
                    list.Add(model);
                }
    
            }
            Dts.Variables["ExcelFilesList"].Value = list;
