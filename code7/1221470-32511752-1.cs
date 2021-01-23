    private DataTable ConvertCSVtoDataTable()
    {
        DataTable dataTable = new DataTable();
        using (StreamReader sr = new StreamReader(csvfilename))
        {
            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(',');
                DataRow dr = dataTable.NewRow();
                for (int i = 0; i < rows.Length; i++)
                {
                    dr[i] = rows[i];
                }
                //IF the dataTable column count is less than the row column count add some columns.
                if (dataTable.Columns.size() < dr.Columns.size()){
                    for(int i = 0; i < dr.Columns.size(); i++){
                       dataTable.Columns.add("");
                    }
                }
                dataTable.Rows.Add(dr);
            }
        }
        return dataTable;
    }
