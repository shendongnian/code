        public static void DataTableToCsv(System.Data.DataTable dt, string csvFile)
        {
            try
            {
                using (TextWriter sUrl = new StreamWriter(csvFile, true, Encoding.Unicode))
                {
                    var columnNames = dt.Columns.Cast<DataColumn>().Select(column => "\"" + column.ColumnName.Replace("\"", "\"\"") + "\"").ToArray();
                    sUrl.WriteLine(string.Join("\t", columnNames));
                    foreach (DataRow row in dt.Rows) // Out of Memory Exception Here
                    {
                        var fields = row.ItemArray.Select(field => "\"" + field.ToString().Replace("\"", "\"\"") + "\"").ToArray();
                        sUrl.WriteLine(string.Join("\t", fields));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }
