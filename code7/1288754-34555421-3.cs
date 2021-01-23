    static IEnumerable<int> GetDividableNumbers(int a, int b, int c)
    {
        int start = Math.Min(a, b);
        int quantity = Math.Abs(a - b);
        return Enumerable.Range(start, quantity).Where(num => num % c == 0);
    }
    static void Main(string[] args)
    {
        foreach (int i in GetDividableNumbers(0, 5, 2))
            Console.WriteLine(i.ToString());
    }
