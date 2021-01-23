    static void Main(string[] args)
    {
        foreach (int i in List())
        {
            Console.WriteLine($"In List foreach {i}");
        }
        Console.WriteLine("*****");
        foreach (int i in Yield())
        {
            Console.WriteLine($"In Yeild foreach {i}");
        }
    }
    private static IEnumerable<int> List()
    {
        var inputList = new List <int> { 1, 2, 3 };
        List<int> outputlist = new List<int>();
        foreach (var i in inputList)
        {
            Console.WriteLine($"In List Method {i}");
            outputlist.Add(i);
        }
            return outputlist.AsEnumerable();
    }
    private static IEnumerable<int> Yield()
    {
        var inputList = new List<int> { 1, 2, 3 };
        foreach (var i in inputList)
        {
            Console.WriteLine($"In Yield Method {i}");
            yield return i;
        }
    }
