    public void PrintLocation(MarsLander ml)
    {
        for (int i = 10; i >= 0 ; i--)
        {
            string locationText = ShouldPrintLocation(ml, i) ? "*" : string.Empty;
            Console.WriteLine("{0} m: {1}", i * 100, locationText);
        }
    
        Console.WriteLine();
    }
