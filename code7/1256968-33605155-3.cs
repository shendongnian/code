    using(var db = new Bootstrap.Database1Entities())
    {
        var item = new CalendarData
                       {
                           Day = new DateTime( 2015, 1, 1 ),
                           Text = "Test"
                       };
        db.CalendarDatas.Add(item);
        db.SaveChanges();
    }
