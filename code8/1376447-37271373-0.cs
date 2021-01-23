    var topTen = flights.
                GroupBy(g => g.Origin).
                Select(g => new { Origin = g.Key, AvgDelay = g.ToList().Average(d => d.DepartureDelay) }).
                OrderByDescending(o => o.AvgDelay).
                Take(10);
