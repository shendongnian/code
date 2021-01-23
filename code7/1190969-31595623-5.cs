    var result = list.GroupBy( result => result.TrdID)
                     .Select( gr => {
                     var startDate = DateTime.ParseExact(gr.OrderBy(x => x.Term).First().Term, "yyyyMM", CultureInfo.InvariantCulture);
                     var endDate = DateTime.ParseExact(gr.OrderByDescending(x => x.Term).First().Term, "yyyyMM", CultureInfo.InvariantCulture);                      
                     return  new ProcessedResult
                     {
                         TrdID = gr.Key
                         StartDate = new DateTime(startDate.Year, startDate.Month, 1),
                         EndDate = (new DateTime(endDate.Year, endDate.Month, 1)).AddMonth(1).AddDays(-1),
                         Price = gr.First().Price,
                         Seller = gr.First().Seller,
                         Buyer = gr.First().Buyer,
                         Quantity = gr.Sum(x=>x.Quantity)
                     } 
                 });
