    static void Main(string[] args)
    {
        var items = new List<string>() { "Hello", "I am a value", "Bye" };
        int i = 1;
        var dict = items.ToDictionary(A => i++, A => A);
    
        foreach (var v in dict)
        {
            Console.WriteLine(v.Key + "   " + v.Value);
        }
    
        Console.ReadLine();    
    }
