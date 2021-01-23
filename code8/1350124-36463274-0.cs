    public static string MyProp { get; } = "Hello!";
    static void Main(string[] args)
    {
        Console.WriteLine(MyProp);
        // prints "Hello!"
        var assembly = Assembly.GetAssembly(typeof(Program));
        Console.WriteLine(assembly.ImageRuntimeVersion);
        // prints "v2.0.50727"
    }
