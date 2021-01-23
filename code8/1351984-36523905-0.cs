    var fruitAnon = fruits
            .GroupBy(item => item.ID)
            .Select(item => new {
                Key = item.Key,
                Count = item.Count()
            })
            .OrderByDescending(item => item.Count)
            .FirstOrDefault();
