    Bar _bar = db.Bars.Find(id);
    var removed =_bar.Foos.Except(bar.Foos);
    var added = bar.Foos.Except(_bar.Foos);
    
    var toRemoveTracked =_bar.Foos.Where(foo => removed.Any(r => r.FooId == foo.FooId))
                                  .ToList();
   
    added.ToList().ForEach(_bar.Foos.Add);
    toRemoveTracked.ForEach((fooo) => {_bar.Foos.Remove(fooo);});
    
    await db.SaveChangesAsync();
