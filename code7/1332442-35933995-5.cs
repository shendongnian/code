    var dateFrom = new DateTime(2015, 03, 03);
    var dateTo = new DateTime(2016, 03, 03);
    var id = "NOT RUN";
    
    var query = from item1 in _db.DailyJobCounts
                where item1.Date >= dateFrom && item1.Date <= dateTo
                from item2 in _db.DailyJobCounts
                where item1.Name == item2.Name && item1.Date < item2.Date && item1.id == id && item2.Name == id
                group new { item1, item2 } by new { item1.Name, item1.Date } into subGroup
                select new
                {
                    subGroup.Key.Name,
                    subGroup.Key.Date,
                    NextDate = subGroup.Min(x => x.item2.Date),
                } into result                        
                select new
                {
                    result.Name,
                    result.Date,
                    result.NextDate,
                    Diff = SqlFunctions.DateDiff("day", result.Date, result.NextDate),
                };
    
    var answer = query.ToList();
