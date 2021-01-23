    var test = "2015-05-08T05:00Z";
    DateTime testTime = new DateTime();
    testTime = DateTime.ParseExact(test, "yyyy-MM-ddTHH:ssZ", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
    Console.WriteLine(testTime);
    Console.ReadLine();
