    DataTable dt = new DataTable();
    dt.Load(reader);
    
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
    								pages = b.Select(s=>s.Field<int>("Page")).ToList() 
    							}).ToList()
    			}).ToList();
