    static Type GetTypeOfSummation<T1, T2>()
    {
        dynamic t1 = default(T1);
        dynamic t2 = default(T2);
        return (t1 + t2).GetType();
    }
    static void Main(string[] args)
    {
        Console.WriteLine(GetTypeOfSummation<int, double>());   // System.Double
        Console.WriteLine(GetTypeOfSummation<int, decimal>());  // System.Decimal
        Console.WriteLine(GetTypeOfSummation<float, double>()); // System.Double
    }
