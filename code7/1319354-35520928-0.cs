    var result = datatable.AsEnumerable()
                          .GroupBy(row=>row.Field<DateTime>("Date"))
                          .Select(gr=>new 
                          {
                              Date = gr.Key,
                              Agents = gr.Select(x => new 
                              {
                                  Id = x.Field<int>("ID"),
                                  Agent = x.Field<string>("Agent")
                              })
                          });
