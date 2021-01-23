        static void exportExcelToTxt(string excelFilePath, string outputTxtPath)
        {
            Dictionary<string, List<long?>> values = new Dictionary<string, List<long?>>();
            using (OleDbConnection excelConnection = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;", excelFilePath)))
            {
                excelConnection.Open();
                string firstSheet = getFirstSheetName(excelConnection);
                using (OleDbCommand cmd = excelConnection.CreateCommand())
                {
                    cmd.CommandText = string.Format("SELECT * FROM [{0}]", firstSheet);
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt); // Getting all the data in the sheet
                            foreach (DataRow item in dt.Rows)
                            {
                                List<long?> toAdd = new List<long?>();
                                string key = item[0] as string;
                                for (int i = 1; i < dt.Columns.Count; i++)
                                {
                                    toAdd.Add(item[i] != DBNull.Value ? (long?)Convert.ToInt64(item[i]) : null);
                                }
                                values.Add(key, toAdd); // Associating all the "numbers" to the "Name"
                            }
                        }
                    }
                }
            }
            StringBuilder toWriteToTxt = new StringBuilder();
            foreach (KeyValuePair<string, List<long?>> item in values)
            {
                // Formatting the output
                toWriteToTxt.Append(string.Format("{0}:", item.Key));
                foreach (long val in item.Value.Where(f => f != null).Distinct())
                {
                    toWriteToTxt.AppendFormat("\t{0} * {1}\r\n", item.Value.Where(f => f == val).Count(),  // Amount of occurrencies of each number
                        val);
                }
            }
            // Writing the TXT
            using (FileStream fs = new FileStream(outputTxtPath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(toWriteToTxt.ToString());
                }
            }
        }
        static string getFirstSheetName(OleDbConnection excelConnection)
        {
            using (DataTable ExcelTables = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" }))
            {
                return ExcelTables.Rows[0]["TABLE_NAME"].ToString();
            }
        }
