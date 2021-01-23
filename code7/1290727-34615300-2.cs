    public class CsvImport
    {
        public static DataTable NewDataTable(string fileName, string delimiters, bool firstRowContainsFieldNames = true)
        {
            DataTable result = new DataTable();
    
            using (TextFieldParser tfp = new TextFieldParser(fileName))
            {
                tfp.SetDelimiters(delimiters); 
    
                // Get Some Column Names
                if (!tfp.EndOfData)
                {
                    string[] fields = tfp.ReadFields();
    
                    for (int i = 0; i < fields.Count(); i++)
                    {
                        if (firstRowContainsFieldNames)
                            result.Columns.Add(fields[i]);
                        else 
                            result.Columns.Add("Col" + i);
                    } 
    
                    if (!firstRowContainsFieldNames)
                        AddCsvRow(result, fields);
                }
    
                // Get Remaining Rows
                while (!tfp.EndOfData)
                {
                    string[] fields = tfp.ReadFields();
    
                    AddCsvRow(result, fields);
                }
            }
    
            return result;
        }
    
        private static void AddCsvRow(DataTable result, string[] fields)
        {
            DataRow row = result.NewRow();
    
            for (int i = 0; i < fields.Count(); i++)
                row[i] = fields[i];
    
            result.Rows.Add(row);
        }
    }
