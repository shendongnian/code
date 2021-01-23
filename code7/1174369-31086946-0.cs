    Dictionary<string, string > dict = new Dictionary<string, string>();
    dict.Add("col1", "ASC");
    dict.Add("col2", "ASC");
    dict.Add("col3", "DESC");
    DataTable dt = new DataTable();
    dt.Columns.Add("col1");
    dt.Columns.Add("col2");
    dt.Columns.Add("col3");
    Random r = new Random();
    for (int i = 0; i < 20; i++)
        dt.Rows.Add(r.Next(10), r.Next(4), r.Next(2));
    string sort = "";
    foreach (KeyValuePair<string, string> entry in dict)
        sort = sort + " " + entry.Key + " " + entry.Value + ",";
    sort = sort.Substring(0, sort.Length - 1).Trim();
    dt.DefaultView.Sort = sort;
    dt = dt.DefaultView.ToTable();
