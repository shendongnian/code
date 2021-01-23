    /* DateTime extension for ranges of dates */
    public static class DateTimeExtensions
    {
        public static IEnumerable<DateTime> EnumerableTo(this DateTime self, DateTime toDate)
        {
            for(var d=self;d<=toDate;d=d.Date.AddDays(1))
               yield return d;
        }
    }
    void Main()
    {
        /* Your example data */
    	var Customers=new [] {
    	  new { id=1,StartDate=new DateTime(2015,1,1),EndDate=new DateTime(2015,1,1)},
    	  new { id=2,StartDate=new DateTime(2015,1,3),EndDate=new DateTime(2015,1,3)},
    	  new { id=3,StartDate=new DateTime(2015,1,3),EndDate=new DateTime(2015,1,5)},
    	  new { id=4,StartDate=new DateTime(2015,1,3),EndDate=new DateTime(2015,1,10)},
    	};
    
        /* The query */
    	var results=Customers
    	   .Select(pair => pair.StartDate.EnumerableTo(pair.EndDate))
    	   .SelectMany(x=>x)
    	   .Distinct();
    							   
    	results.Dump();
    }
