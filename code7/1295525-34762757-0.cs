        public static Func<MyContext,int,IQueryable<Component>> CompiledQuery = (ctx,id) => 
               ctx.Include(c => c.Table1)
                  .Include(c => c.Table2)
                  ...
                  .Include(c => c.Table38)
                  .Where(n => n.Id == id);
       Then in your code you can use `Invoke` to use the query:
        using(var datasource = new MyContext())
        {
            var result = CompiledQuery.Invoke(datasource,2).ToList();
        }
