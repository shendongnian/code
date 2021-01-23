    public string ConvertToXlsx(string xlsPath)
        {
            var oldWorkbook = new HSSFWorkbook(new FileStream(xlsPath, FileMode.Open));
            var oldWorkSheet = oldWorkbook.GetSheetAt(0);
            var newExcelPath = xlsPath.Replace("xls", "xlsx");
            using (var fileStream = new FileStream(newExcelPath, FileMode.Create))
            {
                var newWorkBook = new XSSFWorkbook();
                var newWorkSheet = newWorkBook.CreateSheet("Sheet1");
                foreach (HSSFRow oldRow in oldWorkSheet)
                {
                    var newRow = newWorkSheet.CreateRow(oldRow.RowNum);
                    for (int ii = oldRow.FirstCellNum; ii < oldRow.LastCellNum; ii++)
                    {
                        var newCell = newRow.CreateCell(ii);
                        newCell = oldRow.Cells[ii];
                    }
                }
                newWorkBook.Write(fileStream);
            }
            return newExcelPath;
        }
