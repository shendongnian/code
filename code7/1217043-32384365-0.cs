    static void Main(string[] args)
    {
        int i = 12345;
    
        Console.WriteLine("Test 1: {0:N5}",i);
    
        var formatString = "N5";
    
        Console.WriteLine("Test 2: {0:" + formatString + "}", i);
    
        Console.ReadLine();
    }
