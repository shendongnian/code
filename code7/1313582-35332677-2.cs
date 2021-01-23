    var result = dt.AsEnumerable()
    			.GroupBy(r=>r.Field<int>("StudentId"))
    			.Select(c=> 
    					new Student() 
    					{
    						studentId = c.Key, 
    						Books = c.GroupBy(s=>s.Field<int>("bookId"))
    							.Select(b=> 
    									new Book() 
    									{
    										bookId = b.Key, 
    										pages = b.SelectMany(p=>p.Field<string>("Page").Split(',').Select(int.Parse)).ToList() 
    									}).ToList()
    					}).ToList();
