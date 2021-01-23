    List<MyClass> data = ...; // input
	int gid=0;
	DateTime prevvalue = data[0].ActivityTime;		                    // Initial value 
	
	var result =  data.Select(x=>
	{
		var obj =  x.ActivityTime.Subtract(prevvalue).TotalMinutes<=5?  // Look for timespan difference
					 new {gid= ++gid, item =x}                          // Create groups based on consecutive gaps. 
					:new {gid= gid, item =x};
		prevvalue= x.ActivityTime;                                      // Keep track of previous value (for next element process)
		return obj;
	})
	.GroupBy(x=>x.gid)                                                  // Split into groups 
	.Select(x=>x.Select(s=>s.item).ToList())
	.ToList();
