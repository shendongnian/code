    public static string jsonToCSV(string jsonContent, string delimiter)
            {
                StringWriter csvString = new StringWriter();
                using (var csv = new CsvWriter(csvString))
                {
                    csv.Configuration.SkipEmptyRecords = true;
                    csv.Configuration.WillThrowOnMissingField = false;
                    csv.Configuration.Delimiter = delimiter;
    
                    using (var dt = jsonStringToTable(jsonContent))
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            csv.WriteField(column.ColumnName);
                        }
                        csv.NextRecord();
    
                        foreach (DataRow row in dt.Rows)
                        {
                            for (var i = 0; i < dt.Columns.Count; i++)
                            {
                                csv.WriteField(row[i]);
                            }
                            csv.NextRecord();
                        }
                    }
                }
                return csvString.ToString();
            }
