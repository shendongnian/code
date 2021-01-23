    var first = new[]
                {
                    new RangePeriod(new DateTime(2015, 1, 1), new DateTime(2015, 1, 10)),
                    new RangePeriod(new DateTime(2015, 1, 15), new DateTime(2015, 1, 30))
                };
    var second = new[]
                {
                    new RangePeriod(new DateTime(2015, 1, 2), new DateTime(2015, 1, 20)),
                    new RangePeriod(new DateTime(2015, 1, 25), new DateTime(2015, 1, 25))
                };
    foreach(var range in first.Minus(second)) 
        Console.WriteLine($"{range.StartDate} to {range.EndDate}");
