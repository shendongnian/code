    public static void Main()
    {                          
        Console.WriteLine("give binary values 11001101 and 01010111:");
        byte a = Convert.ToByte(Console.ReadLine(), 2);
        byte b = Convert.ToByte(Console.ReadLine(), 2);
        byte result = (byte)(a ^ b);
        Console.WriteLine(result);        
    }
