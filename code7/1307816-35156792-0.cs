    		List<StatsResult> m_results =
                    (
                      from row in m_table.AsEnumerable()
                      group row by new {
                          EventTime = row.Field<string>("event_time"),
                          Package = row.Field<string>("package"),
                          Name = row.Field<string>("name"),
                          Country = row.Field<string>("country")
                      } into g
                      select new StatsResult()
                      {
                          event_time = g.Key.EventTime,
                          package = g.Key.Package,
                          name = g.Key.Name,
                          country = g.Key.Country,
                          ActiveUsers = g.Sum(x => x.Field<long>("ActiveUsers")),
                          MonthlyActiveUsers = g.Sum(x => x.Field<long>("MonthlyActiveUsers"))
                      }
                    ).ToList();
