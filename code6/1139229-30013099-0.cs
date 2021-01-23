            public void ImportAllFilesOfFolder()
            {
                try
                {
                    DataTable dt = new DataTable();
                    string sourceDir = txtsend.Text;
                    var Icsv = Directory.EnumerateFiles(sourceDir, "*.csv");
                    bool firstFile = true;
                    foreach (string currentfile in Icsv)
                    {
                        using (TextFieldParser parser = new TextFieldParser(currentfile))
                        {
                            parser.TextFieldType = FieldType.Delimited;
                            parser.Delimiters = new string[] { "," };
                            parser.HasFieldsEnclosedInQuotes = true;
                            string[] columns = parser.ReadFields();
                            if (firstFile == true)
                            {
                                for (int i = 0; i < columns.Length; i++)
                                {
                                    dt.Columns.Add(columns[i], typeof(string));
                                }
                            }
                            while (!parser.EndOfData)
                            {
                                string[] fields = parser.ReadFields();
                                DataRow newrow = dt.NewRow();
                                for (int i = 0; i < fields.Length; i++)
                                {
                                    newrow[i] = fields[i];
                                }
                                dt.Rows.Add(newrow);
                            }
                        }
                        firstFile = false;
                    }
                }
                catch (Exception e)
                {
                }
            }​
