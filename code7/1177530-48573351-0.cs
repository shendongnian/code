    using(var ctx = new MyDbContext())
    {
        return ctx.TableA
             .Join(ctx.TableB, a=>a.B_Id, b=>b.Id, (a,b)=>
                  new QueryResult{TableA=a, TableB=b});
    }
