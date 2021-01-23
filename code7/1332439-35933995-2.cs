        var dateFrom = new DateTime(2015, 03, 03);
        var dateTo = new DateTime(2016, 03, 03);
        var id = "NOT RUN";
        var query = from item1 in _db.DailyJobCount
                    from item2 in _db.DailyJobCount
                    where item1.Name == item2.Name && item1.Date < item2.Date && item1.id == id && item2.Name == id
                    group new { item1, item2 } by new { item1.Name, item1.Date } into subGroup
                    select new
                    {
                        subGroup.Key.Name,
                        subGroup.Key.Date,
                        NextDate = subGroup.Min(x => x.item2.Date),
                    } into result
                    where result.Date >= dateFrom && result.Date <= dateTo
                    group result by new { result.Name, result.Date, result.NextDate } into subResult
                    select new
                    {
                        subResult.Key.Name,
                        subResult.Key.Date,
                        subResult.Key.NextDate,
                        Diff = SqlFunctions.DateDiff("day", subResult.Key.Date, subResult.Key.NextDate),
                    };
