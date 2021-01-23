    var data = new List<myClass> {
        new myClass { ActivityTime = new DateTime(2016, 01, 01, 01, 00, 00) },
        new myClass { ActivityTime = new DateTime(2016, 01, 01, 01, 01, 00) },
        new myClass { ActivityTime = new DateTime(2016, 01, 01, 01, 06, 00) },
        new myClass { ActivityTime = new DateTime(2016, 01, 01, 01, 07, 00) },
        new myClass { ActivityTime = new DateTime(2016, 01, 01, 01, 17, 00) }
    };
    
    var period = 5;
    var firstActivityTime = data.Min(x => x.ActivityTime);
    var answer = data.OrderBy(x => x.ActivityTime).GroupBy(x => (x.ActivityTime - firstActivityTime).Minutes / period)
                       .Select(x => x.ToList()).ToList();
