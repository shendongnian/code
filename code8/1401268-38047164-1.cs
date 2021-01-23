    var data = new List<myClass> {
        new myClass { ActivityTime = new DateTime(2016, 01, 01, 01, 00, 00) },
        new myClass { ActivityTime = new DateTime(2016, 01, 01, 01, 05, 00) },
        new myClass { ActivityTime = new DateTime(2016, 01, 01, 01, 06, 00) },
        new myClass { ActivityTime = new DateTime(2016, 01, 01, 01, 07, 00) },
        new myClass { ActivityTime = new DateTime(2016, 01, 01, 01, 17, 00) }
    };
    
    var period = 5;
    var firstActivityTime = data.Min(x => x.ActivityTime);
    var answer = data.OrderBy(x => x.ActivityTime).GroupBy(x => {
            var dif = (x.ActivityTime - firstActivityTime).Minutes;
            return dif / period - (dif % period == 0 && dif / period != 0 ? 1 : 0);
        }).Select(x => x.ToList()).ToList();
