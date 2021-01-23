    private static IEnumerable<int> Items()
    {            
        try
        {
            Console.WriteLine("Before 0");
    
            yield return 0;
    
            Console.WriteLine("Before 1");
    
            yield return 1;
    
            Console.WriteLine("After 1");
        }
        finally 
        {
            Console.WriteLine("Finally");
        }
    }
