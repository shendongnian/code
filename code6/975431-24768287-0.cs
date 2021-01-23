    static void Main(string[] args)
    {
         Test();
         Test();
    }
    static void Test()
    {
         Func<int, int> f = a => a * a;
         int b = f(2);
         Console.WriteLine(b);
    }
