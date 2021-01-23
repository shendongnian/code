    var dt1 = new DateTime(2016, 3, 1, 15, 0, 0, DateTimeKind.Utc);
    var dt2 = new DateTime(2016, 5, 1, 15, 0, 0, DateTimeKind.Utc);
    var s1 = dt1.ToLocalTime().ToString("s");
    var s2 = dt2.ToLocalTime().ToString("s");
 
    Console.WriteLine(s1);  //prints 2016-03-01T16:00:00  because GMT+1 at that date
    Console.WriteLine(s2);  //prints 2016-05-01T17:00:00  because GMT+2 at that date
