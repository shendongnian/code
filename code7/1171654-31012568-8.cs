    var arr = new[]
    {
        new ManagedUDT { m_str01 = "Foo", m_int01 = 1},
        new ManagedUDT { m_str01 = "Bar", m_int01 = 2},
    };
    Console.WriteLine("C#:");
    for (int i = 0; i < arr.Length; i++)
    {
        Console.WriteLine("{0}, {1}", arr[i].m_str01, arr[i].m_int01);
    }
    Console.WriteLine();
    //arr = null;
    GetResultSafeArray(ref arr);
    Console.WriteLine();
    Console.WriteLine("C#:");
    for (int i = 0; i < arr.Length; i++)
    {
        Console.WriteLine("{0}, {1}", arr[i].m_str01, arr[i].m_int01);
    }
