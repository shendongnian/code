    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Foo");
            Environment.FailFast("WOHO!");
        }
        finally { }
    }
