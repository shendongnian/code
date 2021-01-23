    select new 
    {
        Result.Key.Hotel,
        Result.Key.PoliceStation,
        Result.Key.Zone,
        Count = Result.Count()
    };
