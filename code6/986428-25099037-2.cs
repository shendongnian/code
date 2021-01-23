    DateTime epoch = new DateTime(1970, 1, 1);
    var result = (from row in new DataTable().AsEnumerable()
                  group row by new
                               {
                                   Date = row.Field<string>("Date"),
                                   Slice = row.Field<string>("Slice")
                               }
                  into grp
                  select new
                         {
                             AbandonCalls = grp.Sum((r) => Double.Parse(r["AvgAbandonedCalls"].ToString())),
                             Date = ((DateTime.Parse(grp.Key.Date)) - epoch).TotalMilliseconds,
                             grp.Key.Slice
                         }).ToList();
