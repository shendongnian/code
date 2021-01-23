            List<string> newList = new List<string>();
            FileInfo[] excelFiles = di.GetFiles("*.xlsx");
            if (excelFiles.Length > 0)
            {
                foreach (var item in excelFiles)
                {
                    newList.Add(item.FullName);
                }
            }
            Dts.Variables["ExcelFilesList"].Value = newList;
