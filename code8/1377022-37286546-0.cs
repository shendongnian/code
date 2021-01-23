    private static void testFunc()
     {
        var client = (string)AppDomain.CurrentDomain.GetData("client");
        var engine = (int)AppDomain.CurrentDomain.GetData("engine");
    
        Console.WriteLine("client: " + client);
        Console.WriteLine("engine: " + engine);
     }
