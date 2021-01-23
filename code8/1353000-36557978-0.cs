    static int computeProd1(int num1, int num2)
    {
        return (num1 * num2);
    
    }
    
    public static void Main(string[] args)
    
    {
    
        int first, second;
    
        first = Convert.ToInt32(Console.ReadLine());
    
        second = Convert.ToInt32(Console.ReadLine());
    
        int product = computeProd1(first, second);
        Console.WriteLine("Their product is:\t" + product);
    
        Console.ReadLine();// So it wont close.
    }
