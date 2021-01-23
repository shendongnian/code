    static void Main(string[] args)
    {
        BitArray reversedBitArray = null;
        String bitString = String.Empty;
        byte reversedBits = 0;
        byte bits = 0;
        // prompt the user to enter a string of bits
        Console.WriteLine("Enter a string of bits here: ");
        // wait for the user to enter the string of bits
        bitString = Console.ReadLine();
        // convert the string of bits into an integer
        bits = Convert.ToByte(bitString, 2);
        // reverse all of the bits
        reversedBits = ReverseBits(bits);
        // display the reversed bits
        Console.WriteLine("\nThe reversed bit string is...");
        reversedBitArray = new BitArray(new byte[] { reversedBits });
        for (int i = (reversedBitArray.Length - 1); i > 0; i--)
        {
            Console.Write(Convert.ToInt32(reversedBitArray[i]));
        }
        // wait for the user to exit
        Console.WriteLine("\n\nPress any key to exit...");
        Console.ReadKey();
        // exit the console application
        Environment.Exit(0);
    }
