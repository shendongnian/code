    var result = lst.GroupBy(n => n.Id)
        .Select(c => 
        { 
            var firstEl = c.First();
            return new {
                Key = c.Key, 
                total = c.Count(),
                Gender = firstEl.Gender,
                Name = firstEl.Name,
                Course = firstEl.Course
            }
        }).ToList();
