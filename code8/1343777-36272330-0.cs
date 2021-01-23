    DataTable dt = new DataTable();
                dt.Columns.Add("col1");
                dt.Columns.Add("col2");
                dt.Columns.Add("col3");
    
                DataRow dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "20";
                dr[2] = "30";
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
                dr[0] = "100";
                dr[1] = "200";
                dr[2] = "300";
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
                dr[0] = "1000";
                dr[1] = "2000";
                dr[2] = "3000";
                dt.Rows.Add(dr);
    
                List<dynamic> list = new List<dynamic>();
    
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dynamic result = new ExpandoObject();
                    result.name = dt.Columns[i].ColumnName;
                    result.data = dt.Rows.Cast<DataRow>()
                                   .Select(row => row[i])
                                   .ToArray();
                    list.Add(result);
                }
    
                var op = JsonConvert.SerializeObject(list);
