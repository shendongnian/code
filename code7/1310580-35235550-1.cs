    var results = samples.GroupBy(sample => { Year = _dt.Year, Month = _dt.Month DValue = _d})
                         .Select(gr => new {
                             Year = gr.Key.Year,
                             Month = gr.Key.Month,
                             DValue = gr.Key.DValue,
                             AverageValue = gr.Select(item => item.Value).Average()
                         });
