    var categories = GetCategories()
    .GroupBy(x => new { x.Description })
    .Select(group => new
    {
      Categories = group.Key,
      ParentCount = group.Count(),
      ChildCount = group.Where(s => s.ChildCount.HasValue).Count()
    });
