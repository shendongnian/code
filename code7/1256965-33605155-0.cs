    using(var db = new Bootstrap.Database1Entities())
    {
        var item = new db.CalendarData
                       {
                           Day = 1-1-2015,
                           Text = "Test"
                       };
        db.CalendarDatas.Add(item);
        db.SaveChanges();
    }
