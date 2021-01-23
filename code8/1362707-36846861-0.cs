    var lookup = myTest.Where(ItemIsValid)
        .ToLookup(item => new
        {
           item.ID,
           Date = item.EndDate,
        });
