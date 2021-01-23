    // Some mock data...
    var data = new List<Sample>
    {
        new Sample { Time = new DateTime(2016, 1, 1, 0,  1, 00), Value = 10 },
        new Sample { Time = new DateTime(2016, 1, 1, 0,  2, 00), Value = 11 },
        new Sample { Time = new DateTime(2016, 1, 1, 0,  2, 20), Value = 17 },
        new Sample { Time = new DateTime(2016, 1, 1, 0,  2, 30), Value = 13 },
        new Sample { Time = new DateTime(2016, 1, 1, 0,  3, 00), Value = 18 },
        new Sample { Time = new DateTime(2016, 1, 1, 0,  3, 10), Value = 12 },
        new Sample { Time = new DateTime(2016, 1, 1, 0,  4, 00), Value = 19 },
        new Sample { Time = new DateTime(2016, 1, 1, 0,  4, 25), Value = 12 },
        new Sample { Time = new DateTime(2016, 1, 1, 0,  4, 55), Value = 11 },
        new Sample { Time = new DateTime(2016, 1, 1, 0,  5, 00), Value = 12 },
        new Sample { Time = new DateTime(2016, 1, 1, 0,  6, 00), Value = 14 },
        new Sample { Time = new DateTime(2016, 1, 1, 0,  8, 03), Value = 13 },
        new Sample { Time = new DateTime(2016, 1, 1, 0,  8, 44), Value = 17 },
        new Sample { Time = new DateTime(2016, 1, 1, 0,  9, 01), Value = 18 },
        new Sample { Time = new DateTime(2016, 1, 1, 0, 10, 32), Value = 19 },
        new Sample { Time = new DateTime(2016, 1, 1, 0, 10, 54), Value = 15 },
        new Sample { Time = new DateTime(2016, 1, 1, 0, 11, 00), Value = 10 },
        new Sample { Time = new DateTime(2016, 1, 1, 0, 11, 05), Value = 16 },
        new Sample { Time = new DateTime(2016, 1, 1, 0, 11, 10), Value = 14 },
        new Sample { Time = new DateTime(2016, 1, 1, 0, 11, 13), Value = 16 },
        new Sample { Time = new DateTime(2016, 1, 1, 0, 11, 32), Value = 15 },
    };
    
    // The code...
    var range = new TimeSpan(0, 0, 0, 30);
    
    var results = data
        .Select(sample => new
        {
            Time = sample.Time,
            Set = data.Where(relatedSample => relatedSample.Time >= (sample.Time - range) && relatedSample.Time <= (sample.Time + range))
                        .Select(relatedSample => relatedSample.Value)
        })
        .Select(stat => new
        {
            Time = stat.Time,
            Avg = stat.Set.Average(),
            Min = stat.Set.Min(),
            Max = stat.Set.Max(),
            Count = stat.Set.Count()
        });
