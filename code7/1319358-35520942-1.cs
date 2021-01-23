    List<Log> list = new List<Log>()
    {
        new Log(1, "A", new DateTime(2016, 01, 01, 0, 0, 0)),
        new Log(2, "B", new DateTime(2016, 01, 01, 0, 0, 0)),
        new Log(3, "C", new DateTime(2016, 01, 01, 0, 0, 0)),
        new Log(4, "A", new DateTime(2016, 01, 02, 0, 0, 0)),
        new Log(5, "A", new DateTime(2016, 01, 03, 0, 0, 0))
    };
    var result = from entry in list
                 group entry by entry.Date
                 into g
                 select g;
