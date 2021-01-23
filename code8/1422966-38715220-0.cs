    static void Main(string[] args)
    {
        string input = "]  (";
        Console.Write("Input length  {0} : '{1}'  : ", input.Length, input);
        foreach (char cc in input)
        {
            Console.Write("  {0,2:X02}", (int)cc);
        }
        Console.WriteLine();
    }
