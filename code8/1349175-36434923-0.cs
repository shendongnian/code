    public DataTable ConvertTextToDataTable(string filePath, int numberOfColumns)
    {
        DataTable tbl = new DataTable();
        for (int col = 0; col < numberOfColumns; col++)
            tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));
        var lines = System.IO.File.ReadLines(filePath);
        int i = 0;
        foreach (string line in lines)
        {
            var cols = line.Split('\t');
            if (cols.Length > 3 && String.IsNullOrWhiteSpace(cols[3]))
            {
                continue; //Ignore this line 
                
            }
            DataRow dr = tbl.NewRow();
            for (int cIndex = 0; cIndex < numberOfColumns; cIndex++)
            {
                dr[cIndex] = cols[cIndex];
            }
            tbl.Rows.Add(dr);
            i++;
        }
        return tbl;
    }
