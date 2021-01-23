		table.AsEnumerable()
	 		 .Select(r=>new 
                        {
                            c1=r.Field<int>("col1"), 
                            c2 =r.Field<int>("col2"), 
                            c3 =r.Field<int>("col3"), 
                            c4 =r.Field<double>("col4")  
                        })
		     .GroupBy(g=> new {g.c1, g.c2, g.c3})
 			 .Select(x=> new {
				col1 = x.Key.c1,
				col2 = x.Key.c2,
                col3 = x.Key.c3,
				Sum = x.Sum(s=>s.c4)
			});
