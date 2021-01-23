      private void OpenWorkbook(string filename)
        {
            FileInfo info = new FileInfo(filename);
            if (info.Exists == false)
                throw new FileNotFoundException(string.Concat("Excel File '", filename, "' not found."), filename);
            using (FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
                var extension = Path.GetExtension(filename);
                if (extension.ToLowerInvariant() == ".xlsx" || extension.ToLowerInvariant() == ".xlsm")
                {
                    mWorkbook = new XSSFWorkbook(file);
                }
                else
                    mWorkbook = new HSSFWorkbook(file);
                // Next line fix
                Line 101 - mWorkbook.MissingCellPolicy = MissingCellPolicy.CREATE_NULL_AS_BLANK;
                // Previous line fix  
                if (String.IsNullOrEmpty(SheetName))
                    mSheet = mWorkbook.GetSheetAt(mWorkbook.ActiveSheetIndex);  
                else {
                    try {
                        mSheet = mWorkbook.GetSheet(SheetName);
                        if (mSheet == null) {
                            throw new ExcelBadUsageException(string.Concat("The sheet '",
                                SheetName,
                                "' was not found in the workbook."));
                        }
                        var sheetIndex = mWorkbook.GetSheetIndex(mSheet);
                        mWorkbook.SetActiveSheet(sheetIndex);
                    }
                    catch {
                        throw new ExcelBadUsageException(string.Concat("The sheet '",
                            SheetName,
                            "' was not found in the workbook."));
                    }
                }
            }
        }
