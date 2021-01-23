    using (var db = new Entities())
    {
       db.Configuration.LazyLoadingEnabled = false;
       db.Configuration.ProxyCreationEnabled = false;
       var myprojection = db.Table1
                        .Include(x=>x.Table2).Include(x=>x.Table3)
                        .Select(x => new
                        {
                            table1= x,
                            table2= x.Table2.Where(g => Some Condition),
                            table3= x.Table3.Where(g=>Some Condition)
                        })
                        .ToList();
      var result = myprojection.Select(g =>g.table1).FirstOrDefault();
    }
