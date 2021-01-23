    var dt = new DataTable();
    
    var data=Helper.GetData();
    
     foreach (DataRow dr in data)
     {
          List<string> values = new List<string>();
          DataRow dr = dt.NewRow();
          var columns=Helper.GetColumns();
          foreach(var item in columns)
          {
              dr["Id"] = dr[item].ToString();
              values.Add(dr[item].ToString());
          }
          dr["Col1"] = string.Join(",", values);
     } 
