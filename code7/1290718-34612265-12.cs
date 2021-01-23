    public DataTable readCSV(string filePath)
    {
        var dt = new DataTable();
        // Creating the columns
        foreach(var headerLine in File.ReadLines(filePath).Take(1))
        {
            foreach(var headerItem in headerLine.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                dt.Columns.Add(headerItem.Trim());
            }
        }
        // Adding the rows
        foreach(var line in File.ReadLines(filePath).Skip(1))
        {
            dt.Rows.Add(x.Split(';'));
        }
        return dt;
    }
