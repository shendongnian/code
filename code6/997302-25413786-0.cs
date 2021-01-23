    DataTable dt = GetDataTableFromDB();
    var query = dt.AsEnumerable()
                   .Select(r => r.Field<string>("SearchTags").Split(','))
                   .SelectMany(r => r)
                   .GroupBy(r => r)
                   .Select(grp => new
                       {
                           Key = grp.Key,
                           Count = grp.Count()
                       });
