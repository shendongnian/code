    StackOverflowEntities db = new StackOverflowEntities();
            var result = (from p in db.SomeTables
                         join q in db.Table_1 on p.UserName equals q.UserName into Q
                         from q in Q.DefaultIfEmpty()
                         join r in db.Table_2 on p.UserName equals r.UserName into R
                         from r in R.DefaultIfEmpty()
                         join s in db.Table_3 on p.UserName equals s.UserName into S
                         from s in R.DefaultIfEmpty()
                         group new { p, q, r, s } by p.UserName into g
                         select new
                         {
                             UserName = g.Key,
                             tbl1Count = g.Count(w => w.q != null),
                             tbl2Date = g.Max(w => w.r.CreatedDate),
                             tbl3Date = g.Max(w => w.s.SomeDate),
                             SomeDate = g.Max(w => w.p.DateRegistered)
                         }).ToList();
