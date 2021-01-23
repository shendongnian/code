    static void Main()
    {
        long x = 0x1BD11BDAA9FC1A22; 
        var bitstring = Convert.ToString(x, 2) ;    
        Console.WriteLine("Bitstring: " + bitstring);
        var oneBitGroups = bitstring.Split(new char[]{'0'}, StringSplitOptions.RemoveEmptyEntries).Length;
        Console.WriteLine("The number of 1 bit groups is: " + oneBitGroups);
    }
