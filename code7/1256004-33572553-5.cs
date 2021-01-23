    void Main()
    {
        var itemsForMonthYearList=new[]{
    		new ItemsForMonthYear { ItemDescription="A",monthYr="Aug 2014",TotalPackages=1,TotalPurchases=1,AveragePrice=1},
    		new ItemsForMonthYear { ItemDescription="A",monthYr="Sep 2014",TotalPackages=1,TotalPurchases=1,AveragePrice=1},
    		new ItemsForMonthYear { ItemDescription="A",monthYr="Sep 2014",TotalPackages=1,TotalPurchases=1,AveragePrice=1},
    		new ItemsForMonthYear { ItemDescription="A",monthYr="Oct 2014",TotalPackages=1,TotalPurchases=1,AveragePrice=1},
    		new ItemsForMonthYear { ItemDescription="A",monthYr="Oct 2014",TotalPackages=1,TotalPurchases=1,AveragePrice=1},
    		new ItemsForMonthYear { ItemDescription="A",monthYr="Oct 2014",TotalPackages=1,TotalPurchases=1,AveragePrice=1},
    	};
    
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
    	  items.Dump();
    }
    
    public class ItemsForMonthYear
    {
        public String ItemDescription { get; set; }
        public String monthYr { get; set; }
        public int TotalPackages { get; set; }
        public Decimal TotalPurchases { get; set; }
        public Decimal AveragePrice { get; set; }
        public Double PercentOfTotal { get; set; }
    }
