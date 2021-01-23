    var categories = GetCategories()
    .GroupBy(x => new { x.Description })
    .Select(group => new
    {
      Categories = group.Key,
      ParentCount = group.Count(s=>s.ParentCount.HasValue),
      ChildCount = group.Where(s => s.ChildCount.HasValue).Count()
    });
