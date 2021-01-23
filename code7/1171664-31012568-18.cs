    var arr = new[]
    {
        new ManagedUDT { m_str01 = "Foo", m_int01 = 1},
        new ManagedUDT { m_str01 = "Bar", m_int01 = 2},
    };
    {
        Console.WriteLine("C#:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("{0}, {1}", arr[i].m_str01, arr[i].m_int01);
        }
    }
    {
        Console.WriteLine();
        var arr2 = (ManagedUDT[])arr.Clone();
        GetResultSafeArray(ref arr2);
        Console.WriteLine();
        Console.WriteLine("C#:");
        for (int i = 0; i < arr2.Length; i++)
        {
            Console.WriteLine("{0}, {1}", arr2[i].m_str01, arr2[i].m_int01);
        }
    }
    {
        Console.WriteLine();
        ManagedUDT[] arr2;
        IntPtr itypeinfo = Marshal.GetITypeInfoForType(typeof(ManagedUDT));
        GetResultSafeArrayOut(out arr2, itypeinfo);
        Console.WriteLine();
        Console.WriteLine("C#:");
        for (int i = 0; i < arr2.Length; i++)
        {
            Console.WriteLine("{0}, {1}", arr2[i].m_str01, arr2[i].m_int01);
        }
    }
    {
        Console.WriteLine();
        var arr2 = (ManagedUDT[])arr.Clone();
        IntPtr itypeinfo = Marshal.GetITypeInfoForType(typeof(ManagedUDT));
        GetResultSafeArrayRef(ref arr2, itypeinfo);
        Console.WriteLine();
        Console.WriteLine("C#:");
        for (int i = 0; i < arr2.Length; i++)
        {
            Console.WriteLine("{0}, {1}", arr2[i].m_str01, arr2[i].m_int01);
        }
    }
