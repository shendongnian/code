    Console.WriteLine("Character: ");
    string symbol = (Console.ReadLine());
    Console.WriteLine("Peak of Triangle: ");
    int peak = Int32.Parse(Console.ReadLine()); // spaces for triangle
    int i = 0;
    int n = 1;
    while (i != -1) // do it until i is negative
    {
        Console.WriteLine(" ");
        int z = 1;
        while (z <= i) // Symbols for triangle
        {
            Console.Write(symbol);
            z++;
        }
        i += n; // increments when n = 1. decrements when n = -1
        if (i > peak) // if it reached peak then reverse counter.
        {
            n = -1;
            i -= 2; // to fix the star counts. 
        }
    }
