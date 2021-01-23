    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var integers = input.Split(new Char[] { ' ' }).Select(x => Convert.ToInt32(x)).ToList();
    }
