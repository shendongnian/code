    var result = datatable.AsEnumerable()
                              .GroupBy(row=>row.Field<DateTime>("Date"))
                              .Select(gr=>new 
                              {
                                  Date = gr.Key,
                                  Agents = "{"+ string.Join(",", 
                                           gr.Select(x => new 
                                  string.Format("({0},{1})", 
                                      x.Field<int>("ID"), 
                                      x.Field<string>("Agent"))+"}"
                                  })
                              });
