     public static DataTable ReadCSVToDataTable(string path)
        {
            CsvHelper.Configuration.CsvConfiguration config = new CsvHelper.Configuration.CsvConfiguration();
            config.Delimiter = delimeter;
            config.Encoding = new UTF8Encoding(false);
            if (string.IsNullOrEmpty(textQualifier))
            {
                config.QuoteAllFields = false;
            }
            else
            {
                char qualifier = textQualifier.ToCharArray()[0];
                config.Quote = qualifier;
                config.QuoteAllFields = true;
            }
            DataTable dt = new DataTable();
            using (var sr = new StreamReader(path))
            {
                using (var reader = new CsvReader(sr, config))
                {
                    int j = 0;
                    while (reader.Read())
                    {
                        if (j == 0)
                        {
                            if (config.HasHeaderRecord)
                            {
                                foreach (string header in reader.FieldHeaders)
                                    dt.Columns.Add(header);
                            }
                            else
                            {
                                for (int i = 0; i < reader.CurrentRecord.Length; i++)
                                    dt.Columns.Add();
                            }
                            j++;
                        }
                        AddRow(dt, reader);
                    }
                }
            }
            return dt;
        }
