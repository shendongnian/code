        public static DataTable GetDataTableFromCsvString(string csvBody)
        {
            DataTable MethodResult = null;
            try
            {
                MemoryStream MemoryStream = new MemoryStream();
                StreamWriter StreamWriter = new StreamWriter(MemoryStream);
                StreamWriter.Write(csvBody);
                StreamWriter.Flush();
                MemoryStream.Position = 0;
                using (TextFieldParser TextFieldParser = new TextFieldParser(MemoryStream))
                {
                    TextFieldParser.SetDelimiters(new string[] { "," });
                    TextFieldParser.HasFieldsEnclosedInQuotes = true;
                    string[] ColumnFields = TextFieldParser.ReadFields();
                    DataTable dt = new DataTable();
                    foreach (string ColumnField in ColumnFields)
                    {
                        DataColumn DataColumn = new DataColumn(ColumnField);
                        DataColumn.AllowDBNull = true;
                        dt.Columns.Add(DataColumn);
                    }
                    while (!TextFieldParser.EndOfData)
                    {
                        string[] Fields = TextFieldParser.ReadFields();
                        for (int i = 0; i < Fields.Length; i++)
                        {
                            if (Fields[i] == "")
                            {
                                Fields[i] = null;
                            }
                        }
                        dt.Rows.Add(Fields);
                    }
                    MethodResult = dt;
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return MethodResult;
        }
