    var mine = (from x in (from p in mc 
    	                   group p by p.u.id into g1
    					   select new { 
                                 Number = g1.Count(),
    							 Area = g1.Sum(a => a.u.Area??0),
    							 Rent = g1.Sum(a => a.u.Rent??0),
                                 ERV = g1.Sum(a => a.e.ERV ?? 0)
    					   })
    				    group x by 1 into g2
    				    select new myClass {
    							 Number = g2.Count(),
    							 Area = g2.Sum(a => a.Area),
    							 Rent = g2.Sum(a => a.Rent),
                                 ERV = g2.Sum(a => a.ERV)
    					}).FirstOrDefault();
