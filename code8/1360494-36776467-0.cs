    DateTime nine29  = new DateTime(2015, 01, 01, 09, 29, 00);
    DateTime nine30  = new DateTime(2015, 01, 01, 09, 30, 00);
    DateTime runtime = nine30;
    if (runtime.ToUniversalTime() >= nine29.ToUniversalTime() && runtime.ToUniversalTime() < nine29.AddMinutes(1).ToUniversalTime())
        Console.WriteLine("First true");
    if (runtime.ToUniversalTime() >= nine30.ToUniversalTime() && runtime.ToUniversalTime() < nine30.AddMinutes(1).ToUniversalTime())
        Console.WriteLine("Second true");
