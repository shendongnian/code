<!-- -->
    s_field.Enum = MyEnum.A;
    if (Interlocked.CompareExchange(ref s_field.Int, (int)MyEnum.B, (int)MyEnum.A)
        == (int)MyEnum.A)
    {
        Console.WriteLine("Changed from A to B");
    }
