    DataTable dt = new DataTable();
    dt.Columns.Add("myCategory");
    dt.Columns.Add("Name");
    dt.Columns.Add("Score 1");
    dt.Columns.Add("Score 2");
    dt.Columns.Add("Score 3");
    DataRow row = dt.NewRow();
    for (int i = 0; i < myResult.Length; i++)
    {
        row[i] = myResult[i];       
    }
    dt.Rows.Add(row);
