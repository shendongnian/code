    void Main()
    {
        var result = DoWork();
        Console.WriteLine(result);
    }
    
    public double DoWork()
    {
        string inValue;
        double outcome;
    
        Console.WriteLine("Enter amount: ");
        inValue = Console.ReadLine();
        while (!double.TryParse(inValue, out outcome) || outcome <= 0)
        {
            Console.WriteLine("Initial value must be of the type double and greater than 0");
            Console.WriteLine("\nPlease enter the number again: ");
            inValue = Console.ReadLine();
        }
        return outcome;
    }
