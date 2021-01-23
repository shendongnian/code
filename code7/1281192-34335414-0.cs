    Counters counter1 = new Counter() { a = 40; b = 50; c = 60; }
    Type counterType = counter1.GetType();
    foreach (var field in counterType.GetFields())
    {
        var value = Interlocked.Read(field.GetValue(counter1));
    }
