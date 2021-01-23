    var isAvesome = IsAwesome;
    var isAlsoAwesome = IsAlsoAwesome;
    var isVisible = IsVisible;
    var query = dbContext.MainTable
        .AsExpandable()
        .Where(mt => isAwesome.Invoke(mt))
        .SelectMany(s => s.SubTable1.Where(st1 => isAlsoAwesome.Invoke(st1)))
        .Select(sub => new 
        { 
            Sub1sub2s = sub.SubTable2.Where(st2 => isVisible.Invoke(st2)),
            Sub2Mains = sub.MainTable.Where(mt => isAwesome.Invoke(mt))
        });
