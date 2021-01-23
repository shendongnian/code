    public static List<DataTable> ProcessDataTables(string dirPath){
           xlsFiles = System.IO.Directory.GetFiles(dirPath, "*.xls")
           var results = new List<DataTable>
           foreach(var file in xlsFiles) 
                 results.Append(ExcelToDataTable(file))
           return results}
