    var stdList = ... select from DB;
    
    var stdGroups = stdList.GroupBy(x => x.AdmissionNo);
    
    foreach(var group in stdGroups)
    {
      var stds = group.ToList();
    
      var row = dtbl.NewRow(); // a new row of untyped data table
      row["Ad.No"] = stds.First().AdmissionNo;
      // ...set also the other properties
    
      for (int i = model.FromYear; i <= model.ToYear; i++)
      {
        for (int j = model.FromMonth; j <= model.ToMonth; j++)
        {
          for (int k = model.FromDay; k <= model.ToDay; k++)
          {
            var std = stds.Single(x => x.Year == i && x.Month == j && x.Day == k);
            row[GetColumnName(i,j,k)] = std.value;
    
           }
         }
      }
    
      dtbl.Rows.Add(row);
    }
