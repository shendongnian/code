    using (var db = new TestContext()) {
        DateTime startDate = new DateTime(2014,05,01), endDate = new DateTime(2014,06,1);
     
        var baseQuery = db.DevicePropertyUpdates
                            .Where(p => p.TimeStamp >= startDate && p.TimeStamp < endDate)
                            .Where(p => p.Name == "OperatingMode");
     
        var OnSum = baseQuery.Where(p => p.StringValue == "ON")
                           .Sum(p => SqlFunctions.DateDiff("ss",p.TimeStamp, endDate));
        var IdleSum = baseQuery.Where(p => p.StringValue == "IDLE")
                           .Sum(p => SqlFunctions.DateDiff("ss", p.TimeStamp,endDate));
     
        var duration = TimeSpan.FromSeconds(OnSum.Value - IdleSum.Value);
    }
