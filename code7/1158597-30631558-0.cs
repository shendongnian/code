    var duplicates = (from z in dc.MyTables
    				  where (from a in
    							 (from b in dc.MyTables
    							  group b by new { b.ColumnA, b.ColumnB } into c
    							  select new
    							  {
    								  ColumnA = c.Key.ColumnA,
    								  ColumnB = c.Key.ColumnB
    							  })
    							 group a by a.ColumnA into d
    							 where d.Count() > 1
    							 select d.Key).Contains(z.ColumnA)
    					  orderby z.ColumnA ascending
    					  select new
    					  {
    						  ID = z.ID,
    						  ColumnA = z.CourseUrl2,
    						  ColumnB = z.ColumnB
    					  }).ToList();
