    using (var ctx = new TestContext())
    {
    	var query = ctx.Entity_Basics;
    
    	var list = Eval.Execute(@"
    q.Where(x => x.ColumnInt < 10)
     .Select(x => new { x.ID, x.ColumnInt })
     .ToList();", new { q = query });
    }
