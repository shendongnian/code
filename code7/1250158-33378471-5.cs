    List<MyClass> rows = new List<MyClass>();
    // Change the 10 in the following line to increase the number of rows.
    for(double i = 0; i < 10; i++)
    {
        TimeSpan inTime = TimeSpan.FromHours(8 + i / 2);
        TimeSpan outTime = TimeSpan.FromHours(8 + (i + 1) / 2);
        rows.Add(new MyClass(inTime, outTime));
    }
