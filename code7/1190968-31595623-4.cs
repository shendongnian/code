    var result = list.GroupBy( result => result.TrdID)
                     .Select( gr => {
                     var startDate = gr.OrderBy(x=>x.Term).First();
                     var startDateYear = int.Parse(starDate.Substring(0,4));
                     var startDateMonth = int.Parse(starDate.Substring(4,6));
                     var endDate = gr.OrderByDescending(x=>x.Term).First();
                     var endDateYear = int.Parse(endDate.Substring(0,4));
                     var endDateMonth = int.Parse(endDate.Substring(4,6));
                      
                     return  new ProcessedResult
                     {
                         TrdID = gr.Key
                         StartDate = new DateTime(startDateYear, startDateMonth,1),
                         EndDate = (new DateTime(endDateYear, endDateMonth, 1)).AddMonth(1).AddDays(-1),
                         Price = gr.First().Price,
                         Seller = gr.First().Seller,
                         Buyer = gr.First().Buyer,
                         Quantity = gr.Sum(x=>x.Quantity)
                     } 
                 });
