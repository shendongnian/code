    public static DataTable ConvertStringToDataTable(string data)
    {
        DataTable dataTable = new DataTable();
        // extract all lines:
        string[] lines = data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        string header = lines.FirstOrDefault();
        if (header == null)
            return dataTable;
        // first create the columns:
        string[] columns = header.Split(','); // using commas as delimiter is brave ;)
        foreach (string col in columns)
            dataTable.Columns.Add(col.Trim());
        foreach (string line in lines.Skip(1))
        {
            string[] fields = line.Split(',');
            if(fields.Length != dataTable.Columns.Count)
                continue; // should not happen
            DataRow dataRow = dataTable.Rows.Add();
            for (int i = 0; i < fields.Length; i++)
                dataRow.SetField(i, fields[i]);
        }
        return dataTable;
    }
