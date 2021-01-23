    var counter = new List<CounterData>
    {
        new CounterData {counterTime = DateTime.Now.AddMinutes(10), counterName = "counter1" },
        new CounterData {counterTime = DateTime.Now.AddMinutes(15), counterName = "counter2" },
        new CounterData {counterTime = DateTime.Now.AddMinutes(20), counterName = "counter3" },
        new CounterData {counterTime = DateTime.Now.AddMinutes(25), counterName = "counter3" },
        new CounterData {counterTime = DateTime.Now.AddMinutes(30), counterName = "counter1" },
        new CounterData {counterTime = DateTime.Now.AddMinutes(35), counterName = "counter3" },
        new CounterData {counterTime = DateTime.Now.AddMinutes(40), counterName = "counter2" },
        new CounterData {counterTime = DateTime.Now.AddMinutes(45), counterName = "counter1" },
        new CounterData {counterTime = DateTime.Now.AddMinutes(50), counterName = "counter1" },
        new CounterData {counterTime = DateTime.Now.AddMinutes(55), counterName = "counter2" },
    };
    // Now it's grouped by date.
    var groupedCounters = counter.GroupBy(x => x.counterTime.RoundDown(TimeSpan.FromMinutes(15))).Select(d => new { Date = d.Key, Counters = d.ToList() });
    List<CounterData> result = new List<CounterData>();
    // With foreach.
    foreach (var groupedCounter in groupedCounters)
    {
        // Now we group by name as well.
        var countersByName =
            groupedCounter.Counters.GroupBy(x => x.counterName)
                .Select(
                    x =>
                        new CounterData
                        {
                            count = x.Sum(item => item.Count),
                            counterTime = groupedCounter.Date,
                            counterName = x.Key
                        });
        result.AddRange(countersByName);
    }
    // Or with LINQ.
    foreach (var countersByName in groupedCounters.Select(groupedCounter => groupedCounter.Counters.GroupBy(x => x.counterName)
        .Select(
            x =>
                new CounterData
                {
                    count = x.Sum(item => item.Count),
                    counterTime = groupedCounter.Date,
                    counterName = x.Key
                })))
    {
        result.AddRange(countersByName);
    }
