    var grouped = myList.GroupBy(t => t.Created.Year)
        .Select(t => new
        {
            Year = t.Key,
            Months = t.GroupBy(x => x.Created.Month)
                .Select(y => new
                {
                    Month = y.Key,
                    Values = y.ToList()
                 })
        });
