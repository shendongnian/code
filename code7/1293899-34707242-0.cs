     var result =  tablo.AsEnumerable() 
                        .Select(row=> new
                        {
                           X = row.Field<string>("X"),
                           Y = row.Field<string>("Y"),
                           P = row.Filed<int>("P")
                        }).GroupBy(i=>new {X = i.X, Y = i.Y})
                          .Select(gr=>new{
                              X = gr.Key.X,
                              Y = gr.Key.Y
                              P = gr.Max(z => z.P)
                        });
