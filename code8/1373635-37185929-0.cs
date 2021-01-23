    static void Main(string[] args)
    {
        Console.WriteLine(Test1());
        Console.WriteLine(Test2());
        Console.ReadLine();
    }
    static decimal Test1()
    {
        return 10.999999999999999999999M;
    }
    static decimal Test2()
    {
        return (decimal)10.999999999999999999999;
    }
