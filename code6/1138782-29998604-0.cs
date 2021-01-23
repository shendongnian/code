    int cnt = Convert.ToInt32(txtCount.Text);
    DateTime start = Convert.ToDateTime(txtStart.Text);
    DateTime end = Convert.ToDateTime(txtEnd.Text);
    TimeSpan datedifference = end.Subtract(start);
    int dateCount = datedifference.Days;
    float maxUpload = dateCount * 288;  
    float remainingUpload = maxUpload - cnt;
    float averageUpload = remainingUpload / (dateCount * 288) * 100;
    string[,] row1 = { { dateCount.ToString(), maxUpload.ToString(), remainingUpload .ToString(), averageUpload .ToString() } };
    DataTable table = new DataTable();
    table.Columns.Add("DateCount", typeof(string));
    table.Columns.Add("maxUpload", typeof(string));
    table.Columns.Add("remainingUpload", typeof(string));
    table.Columns.Add("averageUpload", typeof(string));
    for (int i = 0; i <= row1.GetUpperBound(0); i++)
    {
        table.Rows.Add();
        table.Rows[i]["DateCount"] = row1[i, 0];
        table.Rows[i]["maxUpload"] = row1[i, 1];
        table.Rows[i]["remainingUpload"] = row1[i, 2];
        table.Rows[i]["averageUpload"] = row1[i, 3];
    }
    gridview1.DataSource = table;
    gridview1.DataBind();
