    static bool Foo(Func<int, int, int> foo, int a, int b)
    {
        return foo(a, b) > 0;  // put breakpoint on this line.
    }
    public static void Test()
    {
        int n = 2;
        int m = 2;
        if (Foo((a, b) => a + b, n, m)) 
        {
            Console.WriteLine("yeah");
        }
    }
