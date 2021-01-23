        public IExcelDataReader getExcelReader()
        {
            return ExcelReaderFactory.CreateReader(System.IO.File.OpenRead(_path));
        }
        public IEnumerable<string> getWorksheetNames()
        {
            var reader = this.getExcelReader();
            var workbook = reader.AsDataSet();
            var sheets = from DataTable sheet in workbook.Tables.Cast<DataTable>() select sheet.TableName;
            return sheets;
        }
        public IEnumerable<DataRow> getData(string sheet, bool firstRowIsColumnNames = false)
        {
            var reader = this.getExcelReader();
            reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = firstRowIsColumnNames
                }
            });
            var workSheet = reader.AsDataSet().Tables[sheet];
            var rows = from DataRow a in workSheet.Rows select a;
            return rows;
        }
        public IEnumerable<DataRow> GetFirstSheetData(bool firstRowIsColumnNames = false)
        {
            var reader = this.getExcelReader();
            reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = firstRowIsColumnNames
                }
            });
            return getData(getWorksheetNames().First());
        }
