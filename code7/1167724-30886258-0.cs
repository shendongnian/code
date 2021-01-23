    var somedates = new List<DateTime>() { 
                DateTime.Now, 
                DateTime.Now.AddDays(10), 
                DateTime.Now.AddMonths(1), 
                DateTime.Now.AddMonths(1).AddDays(5)};
    var months = somedates.GroupBy(x => x.Month).Select(g => new {Name = g.Key, Count = g.Count()});
