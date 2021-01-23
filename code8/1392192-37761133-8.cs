    static void Main(string[] args)
    {
        var storage = new CompoundStorage("consent.png"); // open for read
        foreach (var prop in storage.Properties)
        {
            Console.WriteLine(prop.Name + "=" + prop.Value);
        }
    }
