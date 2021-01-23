    var groups = All_Items.OrderBy(item => item.StartDate).GroupBy(item => item.Category);
    foreach (var group in groups)
    {
    	MyClass last = null;
    	foreach (var item in group)
    	{
    		if (last != null) last.EndDate = item.StartDate.AddDays(-1);
    		last = item;
    	}
    	last.EndDate = new DateTime(2099, 12, 31);
    }
