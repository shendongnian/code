    // Converts Excel To Flat file
            private void ConvertExcelToFlatFile(string excelFilePath, string csvOutputFile, char delimeter, int worksheetNumber = 1)
        {
            if (!File.Exists(excelFilePath)) throw new FileNotFoundException(excelFilePath);
            if (File.Exists(csvOutputFile)) throw new ArgumentException("File exists: " + csvOutputFile);
            // connection string
            var cnnStr = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml; IMEX=1; HDR=NO\"", excelFilePath);
            var cnn = new OleDbConnection(cnnStr);
            // get schema, then data
            var dt = new DataTable();
            try
            {
                cnn.Open();
                var schemaTable = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (schemaTable.Rows.Count < worksheetNumber) throw new ArgumentException("The worksheet number provided cannot be found in the spreadsheet");
                string worksheet = schemaTable.Rows[worksheetNumber - 1]["table_name"].ToString().Replace("'", "");
                string sql = String.Format("select * from [{0}]", worksheet);
                var da = new OleDbDataAdapter(sql, cnn);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                // free resources
                cnn.Close();
            }
            // write out CSV data
            using (var wtr = new StreamWriter(csvOutputFile)) // disposes file handle when done
            {
                foreach (DataRow row in dt.Rows)
                {
                    //MessageBox.Show(row.ItemArray.ToString());
                    bool firstLine = true;
                    foreach (DataColumn col in dt.Columns)
                    {
                        // skip the first line the initial 
                        if (!firstLine)
                        {
                            wtr.Write(delimeter);
                        }
                        else
                        {
                            firstLine = false;
                        }
                        var data = row[col.ColumnName].ToString();//.Replace("\"", "\"\""); // replace " with ""
                        wtr.Write(String.Format("{0}", data));
                    }
                    wtr.WriteLine();
                }
            }
        }
