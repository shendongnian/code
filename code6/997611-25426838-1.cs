    var source = new Data[]
    {
        new Data("Yesterday early", DateTime.Today.AddDays(-1)),
        new Data("Yesterday middle", DateTime.Today.AddDays(-1).AddHours(2)),
        new Data("Yesterday middle", DateTime.Today.AddDays(-1).AddHours(2)),
        new Data("Yesterday late", DateTime.Today.AddDays(-1).AddHours(3)),
        new Data("Today early", DateTime.Today),
        new Data("Today middle", DateTime.Today.AddHours(2)),
        new Data("Today late 1", DateTime.Today.AddHours(3)),
        new Data("Today late 2", DateTime.Today.AddHours(3)),
        new Data("Tomorrow early", DateTime.Today.AddDays(1)),
        new Data("Tomorrow middle", DateTime.Today.AddDays(1).AddHours(2)),
        new Data("Tomorrow late 1", DateTime.Today.AddDays(1).AddHours(3)),
        new Data("Tomorrow late 2", DateTime.Today.AddDays(1).AddHours(3)),
    };
    var lateInDays = source.
        GroupBy((data) => data.TimeStamp.Date).
        Select(dayGroup =>
            new 
            {
                DayGroup = dayGroup, 
                MaxTimeInDay = dayGroup.Max(data => data.TimeStamp)
            }).
        SelectMany((dayGroup) => 
            dayGroup.
                DayGroup.
                Where(data => 
                    (data.TimeStamp == dayGroup.MaxTimeInDay)));
