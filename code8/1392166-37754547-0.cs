    var cheaters = customers.GroupBy(c => c.Id)
        .Select(g => new 
        { 
              Id= g.Key, 
              Percentage = g.Count(c => c.Win > 0) / (double)g.Count()
              // feel free to aggreate other values here like g.Sum(x => x.Stake)
        })
        .Where(c => c.Percentage >= .6);
