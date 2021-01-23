    static void Main(string[] args)
    {
        var container = new Container();
        // Registrations here
        container.RegisterAll<ISimpleLogger>(typeof(DebugLogger), typeof(ConsoleLogger));
        container.Verify();
        Product p = container.GetInstance<Product>();
        p.TestLog();
        Console.ReadKey();
    }
