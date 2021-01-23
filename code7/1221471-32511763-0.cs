    private DataTable ConvertCSVtoDataTable()
    {
        bool firstRow = true;
        DataTable dataTable = new DataTable();
        using (StreamReader sr = new StreamReader(csvfilename))
        {
            while (!sr.EndOfStream)
            {
                string[] values = sr.ReadLine().Split(',');
                if (firstRow)
                {
                    firstRow = false;
                    for (int i = 0;i < values.Length; i++)
                    {
                        dataTable.Columns.Add("Column" + i);
                    }
                }
                DataRow dr = dataTable.NewRow();
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i];
                }
                dataTable.Rows.Add(dr);
            }
        }
        return dataTable;
    }
