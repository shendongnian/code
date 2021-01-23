     var result = from masterFxRate in masterFxRates
                         join masterValue in masterValues on masterFxRate.Currency_code equals masterValue.Text1
                         group masterFxRate by
                         new
                         {
                             masterFxRate.Currency_code
                         } into groupedRates
                         select new
                         {
                             groupedRates.Key.Currency_code,
                             Rate = groupedRates.FirstOrDefault(g => g.Effective_dt != null 
                                                                  && g.Effective_dt == groupedRates.Max(c => c.Effective_dt)).Rate
                         };
            foreach (var item in result)
            {
                Console.WriteLine("{0} : {1} ", item.Currency_code, item.Rate);
            }
