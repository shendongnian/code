    static void Main()
    {
        int i = 1;
        int j = 2;
        Foo(ref i);
        Console.WriteLine(i); // Should print 10
        Bar(j);
        Console.WriteLine(j); // Should print 2
    }
    static void Foo(ref int value)
    {
        value = 10;
    }
    static void Bar(int value)
    {
        value = 15;
    }
