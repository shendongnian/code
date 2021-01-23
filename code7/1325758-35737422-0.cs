    var cities = movements
        .Select(m => new[] { m.MovedFrom, m.MovedTo })
        .SelectMany(n => n)
        .Distinct()
        .OrderBy(n => n)
        .Select(n => new
        {
            category = n,
            leaving = movements.Count(m => m.MovedFrom == n),
            arriving = movements.Count(m => m.MovedTo == n)
        })
        .ToList();
    var result = new
    {
        categories = cities.Select(c => c.category).ToList(),
        leaving = cities.Select(c => c.leaving).ToList(),
        arriving = cities.Select(c => c.arriving).ToList()
    };
    return Json(result);
