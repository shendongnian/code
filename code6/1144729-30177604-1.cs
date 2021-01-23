    var test = "2015-05-08T05:00Z";
    DateTime testTime = new DateTime();
    testTime = DateTime.Parse(test, null, System.Globalization.DateTimeStyles.RoundtripKind);
    Console.WriteLine(testTime);
    Console.ReadLine();
