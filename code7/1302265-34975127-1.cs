    int a = int.Parse("30");
    int b = int.Parse("01");
    int c = int.Parse("2016");
    DateTime date2 = new DateTime(c, b, a); // new DateTime(year, month, day)
    Console.WriteLine(date2.ToString());
