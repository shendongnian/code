            StringBuilder sb = new StringBuilder();
            
            IEnumerable<string> columnNames = resultstable.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in resultstable.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field =>
                  string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText("C:\\path\\Test.csv", sb.ToString());
