    public class CsvImport
    {
        public static DataTable NewDataTable(string fileName, string delimiters, bool firstRowContainsFieldNames = true)
        {
            DataTable result = new DataTable();
    
            using (TextFieldParser tfp = new TextFieldParser(fileName))
            {
                tfp.SetDelimiters(delimiters);
    
                bool firstRowDone = false;
    
                while (!tfp.EndOfData)
                {
                    string[] fields = tfp.ReadFields();
    
                    if (!firstRowDone)
                    {
                        for (int i = 0; i < fields.Count(); i++ ) 
                        {
                            if (firstRowContainsFieldNames)
                                result.Columns.Add(fields[i]);
                            else
                                result.Columns.Add("Col" + i); 
                        }
    
                        firstRowDone = true;
                    }
                     
                    DataRow row = result.NewRow();
    
                    for (int i = 0; i < fields.Count(); i++ ) 
                            row[i] = fields[i];
                    result.Rows.Add(row); 
                }
            }
    
            return result;
        }
    }
