    public IEnumerable<Result> GetResults()
    {
        data = new List<Event>() 
        {
            new Event() { PID = 1, Desc=2 },
            new Event() { PID = 1, Desc=3 },
            new Event() { PID = 2, Desc=4 },
            new Event() { PID = 2, Desc=5 },
            new Event() { PID = 3, Desc=6 }
        };
        var result = from d in data
                     group d.Desc by d.PID into pg
                     select new Result
                     { 
                         Id = pg.Key,  
                         Sum = pg.Sum()
                     };
        return result;
    }
