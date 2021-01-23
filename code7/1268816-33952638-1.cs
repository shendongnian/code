            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            int rowcount = table.Rows.Count;
            int columnCount = table.Columns.Count;
            for (int c = 0; c <= columnCount; c++)
            {
                string columnName = table.Columns[c].ColumnName;
                List<string> tempList = new List<string>();
                for (int r = 0; r <= rowcount; r++)
                {
                    var row = table.Rows[r];
                    if (row[c] != DBNull.Value)
                        tempList.Add((string)row[c]);
                    else
                        tempList.Add(null);
                }
                dict.Add(columnName, tempList);
            }
