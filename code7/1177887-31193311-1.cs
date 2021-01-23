    var bar1 = new Bar { Name = "Bar 1" };
    var bar2 = new Bar { Name = "Bar 2" };
    var bar3 = new Bar { Name = "Bar 3" };
    context.Bars.AddOrUpdate(
        r => r.Name,
        bar1,
        bar2,
        bar3
     );
     context.SaveChanges();
     context.Foos.AddOrUpdate(
         r => r.Name,
         new Foo
         {
             Name = "Foo",
             BarId = bar1.Id
         }
      );
