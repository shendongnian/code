    static void Main(string[] args)
    {
        double length = 0, depth = 0;
        Console.Write("What is the length in feet? ");
        length = Convert.ToDouble(Console.ReadLine());
        Console.Write("What is the depth in feet? ");
        depth = Convert.ToDouble(Console.ReadLine());
        double total = compute(length, depth);
        Console.WriteLine("${0}", total);
        Console.ReadKey();
    }
