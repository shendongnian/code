    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        String month = dateTimePicker1.Value.ToString("MM-yyyy");
        // List<String> dates = new List<string>();
        List<DateRatePair> lstPairs = new List<DateRatePair>();
        String date1;
        cmd.Connection = conn;
        conn.Open();
        cmd.CommandText = ("SELECT Lilie_Date,Rate FROM lilie_master WHERE Lilie_Date LIKE '%" + month + "%'");
        OleDbDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            date1 = rd["Lilie_Date"].ToString();
            if (dates.Contains(date1))
            {
                continue;
            }
            else
            {
                // dates.Add(date1);
                DateRatePair aPair = new DateRatePair();
                aPair.Date = date1;
                aPair.Rate = rd["Rate"].ToString();
                lstPairs.Add(aPair);
            }
        }
        conn.Close();
        DataTable dt = ListToDataTable(lstPairs);
        dataGridView1.DataSource = dt;
        dataGridView1.Refresh();
    }
    private static DataTable ListToDataTable(List<DateRatePair> list)
    {
        DataTable table = new DataTable();
        // DateTime dtime;
        table.Columns.Add("Lilie_Date");
        table.Columns.Add("Rate");
        table.Columns["Lilie_Date"].ReadOnly = true;
        int columns = 0;
        foreach (var array in list)
        {
            if (array.Length > columns)
            {
                columns = array.Length;
            }
        }
        foreach (var array in list)
        {
            DataRow dr = table.NewRow();
            dr["Lilie_Date"] = array.Date;
            dr["Rate"] = array.Rate;
            table.Rows.Add(dr);
        }
        return table;
    }
