        var dateLoc = new DateTime(2016, 8,30 ,0,0,0,DateTimeKind.Local);
        var dateUTC = new DateTime(2016, 8, 30, 0, 0, 0, DateTimeKind.Utc);
        var date = dateLoc.ToString() + " Or " + dateUTC.ToString();
        Console.WriteLine("With Date == {0}", date);
        using (var db = new Db())
        {
            db.Records
                 .Where(x => x.Date  == dateLoc || x.Date == dateUTC) 
                 .ToList()
                 .ForEach(Console.WriteLine);
        }
