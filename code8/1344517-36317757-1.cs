    static void Main(string[] args)
    {
        Tuple<UnionCaseInfo, object[]> results = CsharpPortable.Test.TestIt();
        var uci = results.Item1;
        Console.WriteLine("{0}:", uci.Name);
        foreach (var pi in uci.GetFields())
        {
            Console.WriteLine("Property: {0}", pi.Name);
        }
        Console.ReadKey();
    }
