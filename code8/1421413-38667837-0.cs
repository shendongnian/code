    var best = i.GroupBy(g => g.Id)
                .Select(g => new { 
                    StudentID = g.Key, 
                    Name = g.First().Name, 
                    Average = g.Average(m => m.Marks), 
                    })
                .OrderByDescending(g => g.Average)
                .First();
    // best = { StudentID = 1, Name = Maddy, Average = 84 }
