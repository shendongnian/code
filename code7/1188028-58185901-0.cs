    class ExcelReader {
        public static DataTable ExcelToDataTable(String fileName) {
            using(var stream = File.Open(fileName, FileMode.Open, FileAccess.Read)) {
                using (var reader = ExcelReaderFactory.CreateReader(stream)) {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration() {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration() {
                            UseHeaderRow = true
                        }
                    });
                    DataTableCollection table = result.Tables;
                    DataTable resultTable = table["Blad1"];
                    return resultTable;
                }
            }
        }
    }
