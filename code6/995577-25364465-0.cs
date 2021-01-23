    var result = (from row in InBoundtable.AsEnumerable()
                  where campains.Contains(row.Field<string>("Campaign"))
                  group row by new
                  {
                      Date = row.Field<string>("Date"),
                      Slice = row.Field<string>("Slice")
                  } into grp
                  select new
                  {
                      SL = grp.Sum((r) => Double.Parse(r["Inb.ServiceLevel"].ToString())) / grp.Count(),
                      Date = ((DateTime.Parse(grp.Key.Date.ToString() + " " + grp.Key.Slice.ToString().Split('-')[0])) - epoch).TotalMilliseconds
                  })
                  .OrderBy(r=> r.Date) //HERE
                  .ToList();
