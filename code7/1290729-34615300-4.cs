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
                    // If first line is data then add it
                    if (!firstRowContainsFieldNames)
                        result.Rows.Add(fields); 
                }
                // Get Remaining Rows
                while (!tfp.EndOfData) 
                    result.Rows.Add(tfp.ReadFields());
            }
            return result;
        } 
    }
