    //dont forget using System.Linq;
    using (var context = new FooContext())
    {
       IQueryable<FooClass> rtn = from temp  in context.Foo select temp;
       var list = rtn.ToList();
    }
