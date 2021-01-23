	var items=itemsForMonthYearList.GroupBy(x=>x.monthYr)
	  .Select(x=>new { total=x.Sum(y=>y.TotalPurchases), i=x })
	  .Select(x=>x.i.Select(y=>new ItemsForMonthYear {
	        ItemDescription=y.ItemDescription,
	        monthYr=y.monthYr,
	        TotalPackages=y.TotalPackages,
	        TotalPurchases=y.TotalPurchases,
	        AveragePrice=y.AveragePrice,
	        PercentOfTotal=(double)y.TotalPurchases/(double)x.total
	      }))
	  .SelectMany(x=>x);
