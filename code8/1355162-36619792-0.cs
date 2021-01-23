    static void Main(string[] args)
    {
        Random rnd = new Random();
        int[] mass = Enumerable.Range(0, 10).Select(i => rnd.Next(0, 10)).ToArray();
        Console.WriteLine("display random Massive: ");
        Console.WriteLine(string.Join(" ", mass));
        Console.WriteLine();
        int max = mass.Where(i => (i & 1) == 1).Max();
        Console.WriteLine("max value in Massive = {0}", max);
        Console.ReadLine();
    }
