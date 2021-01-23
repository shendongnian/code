    fooList.GroupBy(g=> new { g.SomeDate.Year })
    	   .Select(s=> 
    			new 
    			{
    				Year = s.Key, 
    				TheContent = s.GroupBy(x=>x.SomeDate.Month)
    					        .Select(m=> 
    							new 
    							{ 
    								Month =  m.Key, 
    								TheSum = m.Sum(e=>e.SomeValue)
    							}).ToList()
    			});
