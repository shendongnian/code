    var result = list.GroupBy( result => result.TrdID)
                     .Select( gr => new ProcessedResult
                     {
                         TrdID = gr.Key
                         StartDate = DateTime.ParseExact(gr.OrderBy(x=>x.Term).First().Term,
    "yyyyMM", CultureInfo.InvariantCulture),
                         EndDate = DateTime.ParseExact(gr.OrderByDescending(x=>x.Term).First().Term,
    "yyyyMM", CultureInfo.InvariantCulture),
                         Price = gr.First().Price,
                         Seller = gr.First().Seller,
                         Buyer = gr.First().Buyer,
                         Quantity = gr.Sum(x=>x.Quantity)
                     });
