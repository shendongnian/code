    static void Main(string[] args)
    {
        List<string> tests = new List<string>();
        tests.Add("Me&You");
        tests.Add("Me|&You");
        tests.Add("Me&|You");
        tests.Add("Me & You");
        foreach (var item in tests)
        {
            Console.WriteLine("{0}: {1}", item,
                              Regex.Replace(item, @"(?<!\|)&(?!\|)", "|&|"));
        }
        Console.ReadKey();
    }
