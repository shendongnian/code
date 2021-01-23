    FileInfo[] excelFiles = di.GetFiles("*.xlsx");
            if (excelFiles.Length > 0)
            {
                foreach(var item in excelFiles)
                    list.Add(new ExcelModel(){ExcelFilePath = item.FullName});
            }
            Dts.Variables["ExcelFilesList"].Value = list;
