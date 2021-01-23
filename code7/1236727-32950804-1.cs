    DateTime MonthStart( DateTime d) { return d.AddDays(-d.Date.Day+1); }
    DateTime MonthEnd( DateTime d) { return MonthStart(d).AddMonths(+1).AddDays(-1); }
    
    IEnumerable<Tuple<DateTime,DateTime>> SplitDates(DateTime start, DateTime end)
    {
    	var dates = new List<Tuple<DateTime,DateTime>>();
    	var t = start;
    	while (t<=end)
    	{
    		if (MonthEnd(t)<=end)
    		{
    			dates.Add(Tuple.Create(t,MonthEnd(t)));
    		}
    		else
    		{
                dates.Add(Tuple.Create(t,end));
    		}
    		t = MonthEnd(t).AddDays(1);
    	}
    	return dates;
    }
    
    void Main()
    {
    	var start = new DateTime(2015,10,05);
    	var end = new DateTime(2016,01,01);
    	var dates = SplitDates(start,end);
    	dates.ToList().ForEach(d => Console.WriteLine("{0} -> {1}",d.Item1.ToShortDateString(),d.Item2.ToShortDateString()));
    }
