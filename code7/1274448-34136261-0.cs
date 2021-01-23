    DataSet ds = new DataSet();
    using (var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(@"C:\Temp\textfile.txt"))
    {
        parser.Delimiters = new string[] { "," };
        parser.HasFieldsEnclosedInQuotes = true; // <--- !!!
        string[] lineFields;
        while ((lineFields = parser.ReadFields()) != null)
        {
            if (lineFields[0].StartsWith(">>"))
            {
                DataTable dt = new DataTable();
                DataColumn[] cols = lineFields
                    .Where(t => !String.IsNullOrWhiteSpace(t))
                    .Select(t => new DataColumn(t.Trim(' ', '>')))
                    .ToArray();
                dt.Columns.AddRange(cols);
                ds.Tables.Add(dt);
            }
            else if(ds.Tables.Count > 0)
            {
                DataTable lastTable = ds.Tables[ds.Tables.Count - 1];
                lineFields = lineFields
                    .Where(t => !String.IsNullOrWhiteSpace(t))
                    .Take(lastTable.Columns.Count)
                    .Select(t => t.Trim())
                    .ToArray();
                lastTable.Rows.Add(lineFields);
            }
        }
    }
