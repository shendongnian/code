    var res = from newset in Dtinfo.AsEnumerable()
                  group newset by newset.Field<DateTime>("wDate")
                      into counter
                      select new
                      {
                          Date = counter.Key,
                          TotalHours = counter.Select(a => a.Field<DateTime>("punchOut") - a.Field<DateTime>("punchIn")).Sum(a => a.TotalHours),
                          Entries = counter.Select(a => new
                          {
                              uid = a.Field<int>("UID"),
                              gDate = a.Field<DateTime>("wDate"),
                              /*other fields here
                               * 
                               * 
                               */
                          })
                      };
