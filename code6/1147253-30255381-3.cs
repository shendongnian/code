    var all = Enumerable.Range(0,24)
                        .SelectMany(x => Enumerable.Range(0,60),
                                   (x,y) => new {Hr = x, Min=y});
            
    var items = new[]{
            new Item{Date = new DateTime(2015,01,01,0,1,0)},
            new Item{Date = new DateTime(2015,01,01,0,1,0)},
            new Item{Date = new DateTime(2015,01,01,0,1,0)},
            new Item{Date = new DateTime(2015,01,01,0,1,0)},
            new Item{Date = new DateTime(2015,01,01,0,1,0)},
            new Item{Date = new DateTime(2015,01,01,0,1,0)},
            new Item{Date = new DateTime(2015,01,01,0,3,0)}
    };
            
    var results = all.GroupJoin(items,
                                x => new {Hour = x.Hr,Minute = x.Min},
                                y => new {Hour = y.Date.Hour,Minute = y.Date.Minute},
                                (x,y) => new {Hour = x.Hr, Minute = x.Min, Count = y.Count()});
                                                     
    foreach(var result in results)
       Console.WriteLine("{0:00}:{1:00} = {2}",result.Hour, result.Minute, result.Count);
