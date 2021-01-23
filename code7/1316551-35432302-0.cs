    var db = CompositionRoot.GetTargetDatabase();
    var targets = from item in db.Targets
                  select item;
    //now targets will be enumarated and can be querable with LINQ to objects
    var filteredTargets = from target in targets.ToList() 
                   where target.RightAscension.IsCloseTo(ra.Value, WithinOneMinute) 
                   && target.Declination.IsCloseTo(dec.Value, WithinOneMinute)
                  select target; 
    var filteredTargets = targets.ToList();
