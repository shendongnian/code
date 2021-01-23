    var activeItems = db.MyEntity.Where(x => x.IsActive);
    
    var query = activeItems.Select(x => new { Name, Value = x.Foo}).Distinct()
        .Concat(activeItems.Select(x => new { Name, Value = x.Bar}).Distinct())        
        .Where(x => x != null)
        .GroupBy(pair => pair.Name)
        .ToDictionary(group => new { group.Key, Count = Group.Count()});
