        public static void WriteToCsvFile(this DataTable dataTable, string filePath) 
        {
            var fileContent = new StringBuilder();
            foreach (var col in dataTable.Columns) {
                fileContent.Append(col + ",");
            }
            fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
            foreach (DataRow dr in dataTable.Rows) {
                foreach (var column in dr.ItemArray) {
                    fileContent.Append("\"" + column + "\",");
                }
                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
            }
            System.IO.File.WriteAllText(filePath, fileContent.ToString());
        }
