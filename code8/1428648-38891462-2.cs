       var counter = new List<CounterData>
        {
            new CounterData {counterTime = DateTime.Now.AddMinutes(10)},
            new CounterData {counterTime = DateTime.Now.AddMinutes(15)},
            new CounterData {counterTime = DateTime.Now.AddMinutes(20)},
            new CounterData {counterTime = DateTime.Now.AddMinutes(25)},
            new CounterData {counterTime = DateTime.Now.AddMinutes(30)},
            new CounterData {counterTime = DateTime.Now.AddMinutes(35)},
            new CounterData {counterTime = DateTime.Now.AddMinutes(40)},
            new CounterData {counterTime = DateTime.Now.AddMinutes(45)},
            new CounterData {counterTime = DateTime.Now.AddMinutes(50)},
            new CounterData {counterTime = DateTime.Now.AddMinutes(55)},
        };
    
        var groupedCounters = counter.GroupBy(x => x.counterTime.RoundUp(TimeSpan.FromMinutes(15))).Select(d => new { Date = d.Key, Counters = d.ToList() });
