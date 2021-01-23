    List<MyClass> rows = new List<MyClass>();
    for(int i = 0; i < 10; i++)
    {
        TimeSpan inTime = TimeSpan.FromHours(8 + i / 2);
        TimeSpan outTime = TimeSpan.FromHours(8 + (i + 1) / 2);
        rows.Add(new MyClass(inTime, outTime));
    }
