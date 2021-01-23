    Dictionary<string, string> dict = new Dictionary<string, string>();
    dict.Add("col1", "asc");
    dict.Add("col2", "desc");
    
    DataTable datatable = new DataTable();
    datatable.Columns.Add("col1");
    datatable.Columns.Add("col2");
    datatable.Rows.Add(new[] {"a", "1"});
    datatable.Rows.Add(new[] {"b", "2"});
    datatable.Rows.Add(new[] {"a", "5"});
    
    datatable.DefaultView.Sort = 
                      String.Join(",", dict.Select(x => x.Key + " " + x.Value).ToArray());
    datatable = datatable.DefaultView.ToTable();
