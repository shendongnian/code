    static void Main(string[] args)
        {
            string sourceFileName = @"C:\Test.xls";
            DataTable dataTable = loadSingleSheet(sourceFileName, "Employee");
            dataTable.Columns.Add("COLUMN_A");
            dataTable.Columns.Remove("COLUMN_B");
        }
    
        private static OleDbConnection ReturnConnection(string fileName)
        {
            return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + "; Jet OLEDB:Engine Type=5;Extended Properties=\"Excel 8.0;\"");
        }
    
        private static DataTable LoadSingleSheet(string fileName, string sheetName)
        {
            DataTable sheetData = new DataTable();
            using (OleDbConnection conn = ReturnConnection(fileName))
            {
                conn.Open();
    
                OleDbDataAdapter sheetAdapter = new OleDbDataAdapter("select columnname from [" + sheetName + "]", conn);
                sheetAdapter.Fill(sheetData);
            }
            return sheetData;
        }
 
    private static void UpdateSingleSheet(string fileName, string sheetName, DataTable dataTable)
        {
            using (OleDbConnection conn = ReturnConnection(fileName))
            {
                conn.Open();
    
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = new OleDbCommand("SELECT columnname FROM [" + sheetName + "]", conn);
    
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
    
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Update(dataTable);
            }
        }
