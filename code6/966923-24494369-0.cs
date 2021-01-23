        public static MemoryStream CreateExcelSheet(DataSet dataToProcess)
        {
            MemoryStream stream = new MemoryStream();
            if (dataToProcess != null)
            {
                var excelworkbook = new HSSFWorkbook();
                foreach (DataTable table in dataToProcess.Tables)
                {
                    var worksheet = excelworkbook.CreateSheet();
                    var headerRow = worksheet.CreateRow(0);
                    foreach (DataColumn column in table.Columns)
                    {
                        headerRow.CreateCell(table.Columns.IndexOf(column)).SetCellValue(column.ColumnName);
                    }
                    //freeze top panel. 
                    worksheet.CreateFreezePane(0, 1, 0, 1);
                    int rowNumber = 1;
                    foreach (DataRow row in table.Rows)
                    {
                        var sheetRow = worksheet.CreateRow(rowNumber++);
                        foreach (DataColumn column in table.Columns)
                        {
                            sheetRow.CreateCell(table.Columns.IndexOf(column)).SetCellValue(row[column].ToString());
                        }
                    }
                }
                excelworkbook.Write(stream);
            }
            return stream;
        }
        public static DataSet CreateDataSetFromExcel(Stream streamToProcess, string fileExtentison = "xlsx")
        {
            DataSet model = new DataSet();
            if (streamToProcess != null)
            {
                if (fileExtentison == "xlsx")
                {
                    XSSFWorkbook workbook = new XSSFWorkbook(streamToProcess);
                    model = ProcessXLSX(workbook);
                }
                else
                {
                    HSSFWorkbook workbook = new HSSFWorkbook(streamToProcess);
                    model = ProcessXLSX(workbook);
                }
            }
            return model;
        }
        private static DataSet ProcessXLSX(HSSFWorkbook workbook)
        {
            DataSet model = new DataSet();
            for (int index = 0; index < workbook.NumberOfSheets; index++)
            {
                ISheet sheet = workbook.GetSheetAt(0);
                if (sheet != null)
                {
                    DataTable table = GenerateTableData(sheet);
                    model.Tables.Add(table);
                }
            }
            return model;
        }
        private static DataTable GenerateTableData(ISheet sheet)
        {
            DataTable table = new DataTable(sheet.SheetName);
            for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                //we will assume the first row are the column names 
                IRow row = sheet.GetRow(rowIndex);
                //a completely empty row of data so break out of the process.
                if (row == null)
                {
                    break;
                }
                if (rowIndex == 0)
                {
                    for (int cellIndex = 0; cellIndex < row.LastCellNum; cellIndex++)
                    {
                        string value = row.GetCell(cellIndex).ToString();
                        if (string.IsNullOrEmpty(value))
                        {
                            break;
                        }
                        else
                        {
                            table.Columns.Add(new DataColumn(value));
                        }
                    }
                }
                else
                {
                    //get the data and add to the collection 
                    //now we know the number of columns to iterate through lets get the data and fill up the table. 
                    DataRow datarow = table.NewRow();
                    object[] objectArray = new object[table.Columns.Count];
                    for (int columnIndex = 0; columnIndex < table.Columns.Count; columnIndex++)
                    {
                        try
                        {
                            ICell cell = row.GetCell(columnIndex);
                            if (cell != null)
                            {
                                objectArray[columnIndex] = cell.ToString();
                            }
                            else
                            {
                                objectArray[columnIndex] = string.Empty;
                            }
                        }
                        catch (Exception error)
                        {
                            Debug.WriteLine(error.Message);
                            Debug.WriteLine("Column Index" + columnIndex);
                            Debug.WriteLine("Row Index" + row.RowNum);
                        }
                    }
                    datarow.ItemArray = objectArray;
                    table.Rows.Add(datarow);
                }
            }
            return table;
        }
        private static DataSet ProcessXLSX(XSSFWorkbook workbook)
        {
            DataSet model = new DataSet();
            for (int index = 0; index < workbook.NumberOfSheets; index++)
            {
                ISheet sheet = workbook.GetSheetAt(index);
                if (sheet != null)
                {
                    DataTable table = GenerateTableData(sheet);
                    model.Tables.Add(table);
                }
            }
            return model;
        }
    }
