        private static DataTable GetDataTabletFromCsvFile(string filePath)
        {
            DataTable MethodResult = null;
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(filePath))
                {
                    MethodResult = GetDataTableFromTextFieldParser(csvReader);
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return MethodResult;
        }
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
                    MethodResult = GetDataTableFromTextFieldParser(TextFieldParser);
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return MethodResult;
        }
        public static DataTable GetDataTableFromTextFieldParser(TextFieldParser textFieldParser)
        {
            DataTable MethodResult = null;
            try
            {
                textFieldParser.SetDelimiters(new string[] { "," });
                textFieldParser.HasFieldsEnclosedInQuotes = true;
                string[] ColumnFields = textFieldParser.ReadFields();
                DataTable dt = new DataTable();
                foreach (string ColumnField in ColumnFields)
                {
                    DataColumn DataColumn = new DataColumn(ColumnField);
                    DataColumn.AllowDBNull = true;
                    dt.Columns.Add(DataColumn);
                }
                while (!textFieldParser.EndOfData)
                {
                    string[] Fields = textFieldParser.ReadFields();
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
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return MethodResult;
        }
