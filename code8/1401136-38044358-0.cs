        public string GetCsv(string[] columns, List<object>[] data)
        {
            StringBuilder CsvData = new StringBuilder();
            //add column headers
            string[] s = new string[columns.length];
            for (Int32 j = 0; j < columns.length; j++)
            {
                s[j] = columns[j];
                if (s[j].Contains("\"")) //replace " with ""
                    s[j].Replace("\"", "\"\"");
                if (s[j].Contains("\"") || s[j].Contains(" ")) //add "'s around any string with space or "
                    s[j] = "\"" + s[j] + "\"";
            }
            CsvData.AppendLine(string.Join(",", s));
            //add rows
            foreach (var row in data)
            {
                for (int j = 0; j < columns.length; j++)
                {
                    s[j] = row[j] == null ? "" : row[j].ToString();
                    if (s[j].Contains("\"")) //replace " with ""
                        s[j].Replace("\"", "\"\"");
                    if (s[j].Contains("\"") || s[j].Contains(" ")) //add "'s around any string with space or "
                        s[j] = "\"" + s[j] + "\"";
                }
                CsvData.AppendLine(string.Join(",", s));
            }
            return CsvData.ToString();
        }
