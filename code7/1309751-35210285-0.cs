        var groupedData = from b in dt.AsEnumerable()
                          group b by int.Parse(b.Field<string>("Column2")) into g
                          select new
                          {
                              column2 = g.Key,
                              column13 = g.Sum(x => decimal.Parse(x.Field<string>("Column13")))
                          };
