    static void Main(string[] args)
    {
        Console.WriteLine("Trinomial Calculator");
        Console.WriteLine("====================");
        Console.ReadLine();
        Console.Clear();
        double[] x =  Calculate(GetValues());
        DisplayResult(x);
    }
