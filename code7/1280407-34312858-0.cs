    new [] {
        States.Changed.SelectUnit(),
        States.ItemChanged.Where(ea => ea.PropertyName == "IsSelected").SelectUnit(),
        Defects.Changed.SelectUnit(),
        Defects.ItemChanged.Where(ea => ea.PropertyName == "IsActive").SelectUnit() }
    .Merge()
    .Select(_ => States.Count(s => s.IsSelected) == 1 && Defects.Any(d => d.IsActive))
