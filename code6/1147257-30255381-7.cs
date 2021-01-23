    var items = new[]{
            new Item{Date = new DateTime(2015,01,01,0,1,0),EndDate = new DateTime(2015,1,1,0,5,0)},
            new Item{Date = new DateTime(2015,01,01,0,1,0),EndDate = new DateTime(2015,1,1,0,5,0)},
            new Item{Date = new DateTime(2015,01,01,0,1,0),EndDate = new DateTime(2015,1,1,0,5,0)},
            new Item{Date = new DateTime(2015,01,01,0,1,0),EndDate = new DateTime(2015,1,1,0,5,0)},
            new Item{Date = new DateTime(2015,01,01,0,1,0),EndDate = new DateTime(2015,1,1,0,5,0)},
            new Item{Date = new DateTime(2015,01,01,0,1,0),EndDate = new DateTime(2015,1,1,0,5,0)},
            new Item{Date = new DateTime(2015,01,01,0,3,0),EndDate = new DateTime(2015,1,1,0,5,0)}
    };
    var results = all.GroupJoin(items.SelectMany(Extrapolate), // extrapolate each item to a list of extrapolated items
                                x => new {Hour = x.Hr,Minute = x.Min},
                                y => new {Hour = y.Hour,Minute = y.Minute},
                                (x,y) => new {Hour = x.Hr, Minute = x.Min, Count = y.Count()});
