    var query =  from row in InBoundtable.AsEnumerable()
                 where campains.Contains(row.Field<string>("Campain"))
                 group row by row.Field <string> ("Date") into grp
                 select new {
                     AbandonCalls = grp.Sum((r) => Double.Parse(r["AvgAbandonedCalls"].ToString())),
                     Date = ((DateTime.Parse(grp.Key)) - epoch).TotalMilliseconds
                 };
    var result = query.ToList();
