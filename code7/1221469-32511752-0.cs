    private DataTable ConvertCSVtoDataTable()
    {
        DataTable dataTable = new DataTable();
        using (StreamReader sr = new StreamReader(csvfilename))
        {
            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(',');
                DataRow dr = dataTable.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dataTable.Rows.Add(dr);
            }
        }
        return dataTable;
    }
