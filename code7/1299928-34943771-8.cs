        public static DataTable GetDataTableFromRemoteCsv(string url, bool isHeadings)
        {
            DataTable MethodResult = null;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader StreamReader = new StreamReader(httpWebResponse.GetResponseStream());
                
                using (TextFieldParser TextFieldParser = new TextFieldParser(StreamReader))
                {
                    if (isHeadings)
                    {
                        MethodResult = GetDataTableFromTextFieldParser(TextFieldParser);
                    }
                    else
                    {
                        MethodResult = GetDataTableFromTextFieldParserNoHeadings(TextFieldParser);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return MethodResult;
        }
        
        private static DataTable GetDataTabletFromCSVFile(string filePath, bool isHeadings)
        {
            DataTable MethodResult = null;
            try
            {
                using (TextFieldParser TextFieldParser = new TextFieldParser(filePath))
                {
                    if (isHeadings)
                    {
                        MethodResult = GetDataTableFromTextFieldParser(TextFieldParser);
                    }
                    else
                    {
                        MethodResult = GetDataTableFromTextFieldParserNoHeadings(TextFieldParser);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return MethodResult;
        }
        public static DataTable GetDataTableFromCsvString(string csvBody, bool isHeadings)
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
                    if (isHeadings)
                    {
                        MethodResult = GetDataTableFromTextFieldParser(TextFieldParser);
                    }
                    else
                    {
                        MethodResult = GetDataTableFromTextFieldParserNoHeadings(TextFieldParser);
                    }
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
        
        public static DataTable GetDataTableFromTextFieldParserNoHeadings(TextFieldParser textFieldParser)
        {
            DataTable MethodResult = null;
            try
            {
                textFieldParser.SetDelimiters(new string[] { "," });
                textFieldParser.HasFieldsEnclosedInQuotes = true;
                
                bool FirstPass = true;
                DataTable dt = new DataTable();
                while (!textFieldParser.EndOfData)
                {
                    string[] Fields = textFieldParser.ReadFields();
                    if(FirstPass)
                    {
                        for (int i = 0; i < Fields.Length; i++)
                        {
                            DataColumn DataColumn = new DataColumn("Column " + i);
                            DataColumn.AllowDBNull = true;
                            dt.Columns.Add(DataColumn);
                        }
                        FirstPass = false;
                    }
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
