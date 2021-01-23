    var items=itemsFormMonthYearList.GroupBy(x=>x.monthYr)
      .Select(x=>new { total=x.Sum(y=>y.TotalPurchase), i=x })
      .Select(x=>i.Select(y=>new ItemsForMonth {
            ItemDescription=y.ItemDescription
            monthYr=y.monthYr
            TotalPackages=y.TotalPackages
            TotalPurchases=y.TotalPurchases
            AveragePrice=y.AveragePrice
            PercentOfTotal=y.TotalPurchases/x.total
          })
      .SelectMany(x=>x);
 
