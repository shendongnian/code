    static void DisplayArray(params int[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            Console.Write("{0}\t", args[i]);
        }
        Console.Write("\n");
    } 
