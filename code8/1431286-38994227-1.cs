    var input = new[]
    {
    	new { Id = 2, Name = "B", ParentId = (int?)1 },
    	new { Id = 1, Name = "A", ParentId = (int?)null },
    }.AsQueryable();
    
    var output1 = input.ApplyOrderBy(e => e.Id).ToList();
    var output2 = input.ApplyOrderBy(e => e.Name).ToList();
    var output3 = input.ApplyOrderBy(e => e.ParentId).ToList();
