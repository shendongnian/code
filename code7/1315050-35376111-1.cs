    public static void Main()
    {
        bool result = true; // some dummy value
    
        int x = 10;
    
        if(result)
        {
            //references x in parent scope
            x = 5;
            //x is already defined, can't define again
            int x = 5;
            Console.WriteLine(x);
        }
    
        Console.WriteLine(x);
    }
