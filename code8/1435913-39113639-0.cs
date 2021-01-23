	var results = (from a in list1
				   join b in list2 on new { a.FormId, a.FormRound } equals new { b.FormId, b.FormRound }
				   group b by new { a.FormId, a.FormRound } into c
				   select new 
				   {
				       c.Key.FormId,
					   c.Key.FormRound,
					   Test1Date = c.Where(d => d.Category == "Test1").Select(e => e.Date).FirstOrDefault(),
					   Test2Date = c.Where(d => d.Category == "Test2").Select(e => e.Date).FirstOrDefault(),
					   Test3Date = c.Where(d => d.Category == "Test3").Select(e => e.Date).FirstOrDefault(),
				   });
